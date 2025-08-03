import { BaseEntity } from "@dkd-query";



/**
 * curdegreesDto
 * @export
 * @interface CurDegreesDto
 */
export interface CurDegreesDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurDegreesDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurDegreesDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurDegreesDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurDegreesDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurDegreesDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurDegreesDto
     */
    name?: string | null;

}

/**
 * curdegreesDto
 * @export
 * @interface CurDegreesCreationDto
 */
export interface CurDegreesCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurDegreesCreationDto
     */
    name?: string | null;
}

/**
 * curdegreesUpdationDto
 * @export
 * @interface CurDegreesUpdationDto
 */
export interface CurDegreesUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurDegreesUpdationDto
     */
    name?: string | null;
} 