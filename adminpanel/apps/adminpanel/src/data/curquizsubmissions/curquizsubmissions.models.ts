import { BaseEntity } from "@dkd-query";



/**
 * curquizsubmissionsDto
 * @export
 * @interface CurQuizsubmissionsDto
 */
export interface CurQuizsubmissionsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurQuizsubmissionsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurQuizsubmissionsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuizsubmissionsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurQuizsubmissionsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuizsubmissionsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurQuizsubmissionsDto
     */
    name?: string | null;

}

/**
 * curquizsubmissionsDto
 * @export
 * @interface CurQuizsubmissionsCreationDto
 */
export interface CurQuizsubmissionsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuizsubmissionsCreationDto
     */
    name?: string | null;
}

/**
 * curquizsubmissionsUpdationDto
 * @export
 * @interface CurQuizsubmissionsUpdationDto
 */
export interface CurQuizsubmissionsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuizsubmissionsUpdationDto
     */
    name?: string | null;
} 