import { BaseEntity } from "@dkd-query";



/**
 * curmaritalstatusesDto
 * @export
 * @interface CurMaritalstatusesDto
 */
export interface CurMaritalstatusesDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurMaritalstatusesDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurMaritalstatusesDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurMaritalstatusesDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurMaritalstatusesDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurMaritalstatusesDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurMaritalstatusesDto
     */
    name?: string | null;

}

/**
 * curmaritalstatusesDto
 * @export
 * @interface CurMaritalstatusesCreationDto
 */
export interface CurMaritalstatusesCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurMaritalstatusesCreationDto
     */
    name?: string | null;
}

/**
 * curmaritalstatusesUpdationDto
 * @export
 * @interface CurMaritalstatusesUpdationDto
 */
export interface CurMaritalstatusesUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurMaritalstatusesUpdationDto
     */
    name?: string | null;
} 