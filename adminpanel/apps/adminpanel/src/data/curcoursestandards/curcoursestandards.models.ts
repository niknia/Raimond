import { BaseEntity } from "@dkd-query";



/**
 * curcoursestandardsDto
 * @export
 * @interface CurCoursestandardsDto
 */
export interface CurCoursestandardsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurCoursestandardsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurCoursestandardsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurCoursestandardsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurCoursestandardsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurCoursestandardsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurCoursestandardsDto
     */
    name?: string | null;

}

/**
 * curcoursestandardsDto
 * @export
 * @interface CurCoursestandardsCreationDto
 */
export interface CurCoursestandardsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurCoursestandardsCreationDto
     */
    name?: string | null;
}

/**
 * curcoursestandardsUpdationDto
 * @export
 * @interface CurCoursestandardsUpdationDto
 */
export interface CurCoursestandardsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurCoursestandardsUpdationDto
     */
    name?: string | null;
} 