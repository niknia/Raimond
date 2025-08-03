import { BaseEntity } from "@dkd-query";



/**
 * curschedulesDto
 * @export
 * @interface CurSchedulesDto
 */
export interface CurSchedulesDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurSchedulesDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurSchedulesDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurSchedulesDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurSchedulesDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurSchedulesDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurSchedulesDto
     */
    name?: string | null;

}

/**
 * curschedulesDto
 * @export
 * @interface CurSchedulesCreationDto
 */
export interface CurSchedulesCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurSchedulesCreationDto
     */
    name?: string | null;
}

/**
 * curschedulesUpdationDto
 * @export
 * @interface CurSchedulesUpdationDto
 */
export interface CurSchedulesUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurSchedulesUpdationDto
     */
    name?: string | null;
} 