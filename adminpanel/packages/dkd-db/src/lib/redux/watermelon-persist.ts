import type { Database, Model } from '@nozbe/watermelondb';
import type { Collection } from '@nozbe/watermelondb';
import { createTransform } from 'redux-persist';
import type { Observable } from 'rxjs';

// Define a replacement for _RawRecord
type RawRecord = Record<string, unknown>;

export interface WatermelonModel extends Model {
  version?: number;
}

export interface WatermelonPersistConfig<T extends WatermelonModel> {
  key: string;
  database: Database;
  collection: string;
  version?: number;
  serialize?: (data: T) => Partial<RawRecord>;
  deserialize?: (model: RawRecord) => Partial<T>;
}

interface StorageData<T> {
  data: Partial<RawRecord>[];
  version: number;
}

interface GenericState<T> {
  data: T[];
  version?: number;
  status?: string;
  error?: string | null;
  lastUpdated?: number;
}

interface DataContainer {
  data: unknown[];
}

const ensureArray = <T>(value: unknown): T[] => {
  if (Array.isArray(value)) {
    return value as T[];
  }
  if (value && typeof value === 'object') {
    const container = value as Partial<DataContainer>;
    if ('data' in container && Array.isArray(container.data)) {
      return container.data as T[];
    }
  }
  return [];
};

export const createWatermelonStorage = <T extends WatermelonModel>(config: WatermelonPersistConfig<T>) => {
  const collection = config.database.get<T>(config.collection);

  return {
    getItem: async (key: string): Promise<string | null> => {
      try {
        const records = await collection.query().fetch();
        const data = records.map(record => {
          return config.deserialize ? config.deserialize(record._raw) : record._raw;
        });
        const result: StorageData<T> = {
          data: data.map(d => d as Partial<RawRecord>),
          version: config.version || 1,
        };
        return JSON.stringify(result);
      } catch (error) {
        console.error('Error loading data:', error);
        return null;
      }
    },

    setItem: async (key: string, value: string): Promise<void> => {
      try {
        let parsed: unknown;
        try {
          parsed = JSON.parse(value);
        } catch (e) {
          console.error('Failed to parse value:', e);
          return;
        }

        const data = ensureArray<Partial<RawRecord>>(parsed);
        const version = typeof parsed === 'object' && parsed 
          ? (parsed as StorageData<T>)?.version || config.version || 1 
          : config.version || 1;

        await config.database.write(async () => {
          // Clear existing records
          const existingRecords = await collection.query().fetch();
          if (existingRecords.length > 0) {
            await config.database.batch(
              ...existingRecords.map(record => record.prepareDestroyPermanently())
            );
          }

          // Create new records
          if (data.length > 0) {
            const operations = data.map((item) => {
              const recordData = config.serialize 
                ? config.serialize(item as unknown as T) 
                : (item as Partial<RawRecord>);
              
              return collection.prepareCreate((record: T) => {
                Object.assign(record, recordData);
                if (typeof version === 'number') {
                  record.version = version;
                }
              });
            });

            await config.database.batch(...operations);
          }
        });
      } catch (error) {
        console.error('Error storing data:', error);
      }
    },

    removeItem: async (key: string): Promise<void> => {
      try {
        await config.database.write(async () => {
          const records = await collection.query().fetch();
          if (records.length > 0) {
            await config.database.batch(
              ...records.map(record => record.prepareDestroyPermanently())
            );
          }
        });
      } catch (error) {
        console.error('Error removing data:', error);
      }
    },
  };
};

export const createWatermelonTransform = <T extends WatermelonModel>(config: WatermelonPersistConfig<T>) => {
  const collection = config.database.get<T>(config.collection);

  return createTransform(
    // Transform state going to storage
    (state: GenericState<T>) => {
      if (!state || !state.data) {
        return {
          data: [],
          version: config.version || 1,
        };
      }

      const data = ensureArray<T>(state.data);
      return {
        data: data.map(item => {
          if (!item || typeof item !== 'object') {
            console.warn('Invalid item in state data:', item);
            return {} as Partial<RawRecord>;
          }
          return config.serialize ? config.serialize(item) : (item._raw as Partial<RawRecord>);
        }),
        version: state.version || config.version || 1,
      };
    },
    // Transform state being rehydrated
    (state: StorageData<T>): GenericState<T> => {
      if (!state || !state.data) {
        return {
          data: [],
          version: config.version || 1,
          status: 'idle',
          error: null,
          lastUpdated: Date.now(),
        };
      }

      const data = ensureArray<Partial<RawRecord>>(state.data);
      return {
        data: data.map(item => {
          const model = collection.prepareCreate((record: T) => {
            Object.assign(record, item);
            if (typeof state?.version === 'number') {
              record.version = state.version;
            }
          });
          return model;
        }),
        version: state.version || config.version || 1,
        status: 'idle',
        error: null,
        lastUpdated: Date.now(),
      };
    },
    { whitelist: [config.key] }
  );
};

export const observeCollection = <T extends WatermelonModel>(
  database: Database,
  collection: string
): Observable<T[]> => {
  const dbCollection = database.get<T>(collection);
  return dbCollection.query().observe() as Observable<T[]>;
}; 