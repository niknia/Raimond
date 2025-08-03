import type { BaseEntity, Result } from '@dkd-query';

export interface SfrOwnerDto extends BaseEntity{
    id: number;
    name?: string | null;
}

/**
 * 
 * @export
 * @interface SfrOwnerCreationDto
 */
export interface SfrOwnerCreationDto {
    /**
     * 
     * @type {string}
     * @memberof SfrOwnerCreationDto
     */
    name?: string | null;
}
/**
 * 
 * @export
 * @interface SfrOwnerUpdationDto
 */
export interface SfrOwnerUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof SfrOwnerUpdationDto
     */
    name?: string | null;
}

export type SfrOwnerResult = Result<SfrOwnerDto[]>;