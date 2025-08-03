import { BaseEntity } from "@dkd-query";



/**
 * curscourseobjectivesDto
 * @export
 * @interface CurScourseobjectivesDto
 */
export interface CurScourseobjectivesDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurScourseobjectivesDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurScourseobjectivesDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurScourseobjectivesDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurScourseobjectivesDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurScourseobjectivesDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurScourseobjectivesDto
     */
    name?: string | null;

}

/**
 * curscourseobjectivesDto
 * @export
 * @interface CurScourseobjectivesCreationDto
 */
export interface CurScourseobjectivesCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurScourseobjectivesCreationDto
     */
    name?: string | null;
}

/**
 * curscourseobjectivesUpdationDto
 * @export
 * @interface CurScourseobjectivesUpdationDto
 */
export interface CurScourseobjectivesUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurScourseobjectivesUpdationDto
     */
    name?: string | null;
} 