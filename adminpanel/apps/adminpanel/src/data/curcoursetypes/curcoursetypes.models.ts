import { BaseEntity } from "@dkd-query";



/**
 * curcoursetypesDto
 * @export
 * @interface CurCoursetypesDto
 */
export interface CurCoursetypesDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurCoursetypesDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurCoursetypesDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurCoursetypesDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurCoursetypesDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurCoursetypesDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurCoursetypesDto
     */
    name?: string | null;

}

/**
 * curcoursetypesDto
 * @export
 * @interface CurCoursetypesCreationDto
 */
export interface CurCoursetypesCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurCoursetypesCreationDto
     */
    name?: string | null;
}

/**
 * curcoursetypesUpdationDto
 * @export
 * @interface CurCoursetypesUpdationDto
 */
export interface CurCoursetypesUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurCoursetypesUpdationDto
     */
    name?: string | null;
} 