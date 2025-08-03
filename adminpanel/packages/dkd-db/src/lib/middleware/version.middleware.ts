import { Model } from '@nozbe/watermelondb';

export interface VersionedModel extends Model {
  version: number;
}

export interface Migration<T extends VersionedModel> {
  version: number;
  migrate: (record: T) => Partial<T>;
}

export interface VersionConfig<T extends VersionedModel> {
  version: number;
  migrations: Migration<T>[];
}

export const createVersionMiddleware = <T extends VersionedModel>(config: VersionConfig<T>) => {
  return {
    beforeUpdate: async (record: T, changes: Partial<T>) => {
      const currentVersion = record.version || 0;
      const targetVersion = config.version;

      if (currentVersion < targetVersion) {
        const pendingMigrations = config.migrations
          .filter((migration) => migration.version > currentVersion)
          .sort((a, b) => a.version - b.version);

        for (const migration of pendingMigrations) {
          const migrationChanges = migration.migrate(record);
          await record.update((rec) => {
            Object.assign(rec, migrationChanges);
            (rec as T).version = migration.version;
          });
        }
      }

      return {
        ...changes,
        version: targetVersion,
      };
    },
  };
}; 