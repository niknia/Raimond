/**
 * @monorepo/watermelon-repository
 * A repository pattern implementation for WatermelonDB
 */

import type { Database, Model, TableName, Collection } from '@nozbe/watermelondb';
import type { Observable } from 'rxjs';
import { Q } from '@nozbe/watermelondb';
import { map } from 'rxjs/operators';
import withObservables from '@nozbe/with-observables';

// Base Repository Interface
export interface Repository<T extends Model> {
  observeAll(): Observable<T[]>;
  observeById(id: string): Observable<T | null>;
  observeQuery(query: Q.Clause[]): Observable<T[]>;
  create(data: Partial<T>): Promise<T>;
  update(id: string, data: Partial<T>): Promise<T>;
  delete(id: string): Promise<void>;
  deleteAll(): Promise<void>;
  find(id: string): Promise<T | null>;
  findAll(): Promise<T[]>;
  query(query: Q.Clause[]): Promise<T[]>;
}

// Standard Repository Implementation
export class WatermelonRepository<T extends Model> implements Repository<T> {
  private collection: Collection<T>;

  constructor(database: Database, tableName: TableName<T>) {
    this.collection = database.get<T>(tableName);
  }

  observeAll(): Observable<T[]> {
    return this.collection.query().observe();
  }

  observeById(id: string): Observable<T | null> {
    return this.collection.query(Q.where('id', id)).observe().pipe(
      map((records: T[]) => records[0] || null)
    );
  }

  observeQuery(query: Q.Clause[]): Observable<T[]> {
    return this.collection.query(...query).observe();
  }

  async create(data: Partial<T>): Promise<T> {
    let record: T | undefined;
    await this.collection.database.action(async () => {
      record = await this.collection.create((newRecord) => {
        Object.assign(newRecord, data);
      });
    });
    if (!record) {
      throw new Error('Failed to create record');
    }
    return record;
  }

  async update(id: string, data: Partial<T>): Promise<T> {
    const record = await this.find(id);
    if (!record) {
      throw new Error(`Record with id ${id} not found`);
    }

    await this.collection.database.action(async () => {
      await record.update(() => {
        Object.assign(record, data);
      });
    });

    return record;
  }

  async delete(id: string): Promise<void> {
    const record = await this.find(id);
    if (!record) {
      throw new Error(`Record with id ${id} not found`);
    }

    await this.collection.database.action(async () => {
      await record.markAsDeleted();
    });
  }

  async deleteAll(): Promise<void> {
    const records = await this.findAll();
    await this.collection.database.action(async () => {
      await Promise.all(records.map(record => record.markAsDeleted()));
    });
  }

  async find(id: string): Promise<T | null> {
    try {
      return await this.collection.find(id);
    } catch {
      return null;
    }
  }

  async findAll(): Promise<T[]> {
    return await this.collection.query().fetch();
  }

  async query(query: Q.Clause[]): Promise<T[]> {
    return await this.collection.query(...query).fetch();
  }
}

// Utilities
export { withObservables };
export type { Database, Model };
