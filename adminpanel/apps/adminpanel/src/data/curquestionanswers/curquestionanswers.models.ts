import { BaseEntity } from "@dkd-query";



/**
 * curquestionanswersDto
 * @export
 * @interface CurQuestionanswersDto
 */
export interface CurQuestionanswersDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurQuestionanswersDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurQuestionanswersDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuestionanswersDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurQuestionanswersDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuestionanswersDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurQuestionanswersDto
     */
    name?: string | null;

}

/**
 * curquestionanswersDto
 * @export
 * @interface CurQuestionanswersCreationDto
 */
export interface CurQuestionanswersCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuestionanswersCreationDto
     */
    name?: string | null;
}

/**
 * curquestionanswersUpdationDto
 * @export
 * @interface CurQuestionanswersUpdationDto
 */
export interface CurQuestionanswersUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuestionanswersUpdationDto
     */
    name?: string | null;
} 