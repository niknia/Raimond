import type { Database, Model } from '@nozbe/watermelondb';
import { BaseRepository } from './baseRepository.js';
import type { EntityModel } from '../interfaces/types.js';

/**
 * Generic repository implementation that can be used directly
 */
export class GenericRepository<T extends EntityModel, M extends Model> extends BaseRepository<T, M> {} 