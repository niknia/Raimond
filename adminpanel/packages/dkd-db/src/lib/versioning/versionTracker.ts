import type { Database, Model } from '@nozbe/watermelondb';
import type { EntityModel } from '../interfaces/types.js';

// Version tracking functionality for entities
export class VersionTracker<T extends EntityModel> {
  private database: Database;
  private modelName: string;

  constructor(database: Database, modelName: string) {
    this.database = database;
    this.modelName = modelName;
  }

  // Track version changes for an entity
  async trackVersion(entity: T, changes: Partial<T>): Promise<void> {
    const collection = this.database.get(this.modelName);
    const currentVersion = entity.version || 0;
    const newVersion = currentVersion + 1;

    await this.database.write(async () => {
      const model = await collection.find(entity.id);
      await model.update((record: Model) => {
        Object.assign(record, {
          ...changes,
          version: newVersion,
          updatedAt: Date.now()
        });
      });
    });
  }

  // Get version history for an entity
  async getVersionHistory(entityId: string): Promise<T[]> {
    const collection = this.database.get(this.modelName);
    const model = await collection.find(entityId);
    const raw = model._raw;

    return [{
      id: model.id,
      version: (raw as Record<string, unknown>).version as number,
      createdAt: (raw as Record<string, unknown>).createdAt as number,
      updatedAt: (raw as Record<string, unknown>).updatedAt as number,
      ...Object.keys(raw)
        .filter(key => !['id', '_status', '_changed', 'version', 'createdAt', 'updatedAt'].includes(key))
        .reduce((obj, key) => {
          obj[key.replace(/^_/, '')] = (raw as Record<string, unknown>)[key];
          return obj;
        }, {} as Record<string, unknown>)
    } as T];
  }
} 