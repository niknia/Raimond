import { BaseEntity } from "@dkd-query";



/**
 * curquestionsDto
 * @export
 * @interface CurQuestionsDto
 */
export interface CurQuestionsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurQuestionsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurQuestionsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuestionsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurQuestionsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuestionsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurQuestionsDto
     */
    name?: string | null;

}

/**
 * curquestionsDto
 * @export
 * @interface CurQuestionsCreationDto
 */
export interface CurQuestionsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuestionsCreationDto
     */
    name?: string | null;
}

/**
 * curquestionsUpdationDto
 * @export
 * @interface CurQuestionsUpdationDto
 */
export interface CurQuestionsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuestionsUpdationDto
     */
    name?: string | null;
} 