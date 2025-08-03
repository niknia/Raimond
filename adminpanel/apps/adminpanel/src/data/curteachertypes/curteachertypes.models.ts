import { BaseEntity } from "@dkd-query";



/**
 * curteachertypesDto
 * @export
 * @interface CurTeacherTypesDto
 */
export interface CurTeacherTypesDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurTeacherTypesDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurTeacherTypesDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeacherTypesDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurTeacherTypesDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeacherTypesDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurTeacherTypesDto
     */
    name?: string | null;

}

/**
 * curteachertypesDto
 * @export
 * @interface CurTeacherTypesCreationDto
 */
export interface CurTeacherTypesCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurTeacherTypesCreationDto
     */
    name?: string | null;
}

/**
 * curteachertypesUpdationDto
 * @export
 * @interface CurTeacherTypesUpdationDto
 */
export interface CurTeacherTypesUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurTeacherTypesUpdationDto
     */
    name?: string | null;
}
