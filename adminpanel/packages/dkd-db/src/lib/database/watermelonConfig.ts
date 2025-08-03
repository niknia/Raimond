import { Database, appSchema, tableSchema } from '@nozbe/watermelondb';
import type { Model, ColumnType } from '@nozbe/watermelondb';
// @ts-ignore - Import LokiJSAdapter
import LokiJSAdapter from '@nozbe/watermelondb/adapters/lokijs';

/**
 * Column definition type with proper format
 */
type ColumnDefinition = {
  name: string;
  type: ColumnType;
  isOptional?: boolean;
  isIndexed?: boolean;
};

/**
 * Create a standard schema for WatermelonDB models
 * @param tableName - Name of the table/collection
 * @param tableFields - List of field names to include in schema
 */
export function createWatermelonModel(tableName, tableFields) {
  return {
    name: tableName,
    columns: tableFields.reduce((acc, field) => {
      acc[field] = { type: 'string' };
      return acc;
    }, {
      created_at: { type: 'number' },
      updated_at: { type: 'number' },
      version: { type: 'number' }
    })
  };
}

/**
 * Create an initial state schema for Redux
 * @param entityName - Name of the entity
 */
export function createReduxStateSchema<T>(entityName: string) {
  return {
    entities: {} as Record<string, T>,
    ids: [] as string[],
    loading: false,
    error: null as string | null
  };
}

/**
 * Initialize the database with models and migrations
 * @param models - Model classes to register
 * @param migrations - Optional migrations
 * @param database - Optional existing database instance
 */
export function initializeDatabase(models, migrations, database) {
  // If a database is provided, use it
  if (database) {
    return database;
  }

  // Create a schema for the database
  const schema = appSchema({
    version: 1,
    tables: models
  });

  // Create an adapter for the database
  // @ts-ignore - LokiJSAdapter may have compatibility issues with ESM
  const adapter = new LokiJSAdapter({
    schema,
    useWebWorker: false,
    useIncrementalIndexedDB: true
  });

  // Create a database instance
  return new Database({
    adapter,
    modelClasses: models
  });
} 