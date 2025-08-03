import type { Database, Model } from '@nozbe/watermelondb';
import type { EntityModel } from '../interfaces/types.js';

// Create storage adapter for WatermelonDB
export function createWatermelonStorage<T extends EntityModel, M extends Model>(
  database: Database,
  modelName: string
) {
  return {
    getItem: async (key: string): Promise<string | null> => {
      try {
        const collection = database.get(modelName);
        const model = await collection.find(key);
        return JSON.stringify(model._raw);
      } catch (error) {
        console.error('WatermelonDB storage getItem error:', error);
        return null;
      }
    },

    setItem: async (key: string, value: string): Promise<void> => {
      const collection = database.get(modelName);
      const data = JSON.parse(value);

      await database.write(async () => {
        const model = await collection.find(key);
        await model.update((record: any) => {
          Object.assign(record, data);
        });
      });
    },

    removeItem: async (key: string): Promise<void> => {
      const collection = database.get(modelName);
      await database.write(async () => {
        const model = await collection.find(key);
        await model.markAsDeleted();
      });
    }
  };
}

// Create transform for WatermelonDB data
export function createWatermelonTransform<T extends EntityModel>() {
  return {
    in: (state: T): Record<string, unknown> => {
      const { id, createdAt, updatedAt, version, ...rest } = state;
      return rest;
    },

    out: (raw: Record<string, unknown>): T => {
      return {
        id: raw.id as string,
        createdAt: raw.createdAt as number,
        updatedAt: raw.updatedAt as number,
        version: raw.version as number,
        ...raw
      } as T;
    }
  };
}

// Observe collection changes
export function observeCollection<T extends EntityModel, M extends Model>(
  database: Database,
  modelName: string,
  callback: (entities: T[]) => void
) {
  const collection = database.get(modelName);
  
  return collection.query().observe().subscribe(models => {
    const entities = models.map(model => {
      const raw = (model as M)._raw;
      return {
        id: model.id,
        ...Object.keys(raw)
          .filter(key => !['id', '_status', '_changed'].includes(key))
          .reduce((obj, key) => {
            // @ts-ignore
            obj[key.replace(/^_/, '')] = raw[key];
            return obj;
          }, {} as any)
      } as T;
    });
    
    callback(entities);
  });
} 