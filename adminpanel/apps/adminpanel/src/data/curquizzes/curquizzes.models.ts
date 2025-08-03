import { BaseEntity } from "@dkd-query";



/**
 * curquizzesDto
 * @export
 * @interface CurQuizzesDto
 */
export interface CurQuizzesDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurQuizzesDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurQuizzesDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuizzesDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurQuizzesDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQuizzesDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurQuizzesDto
     */
    name?: string | null;

}

/**
 * curquizzesDto
 * @export
 * @interface CurQuizzesCreationDto
 */
export interface CurQuizzesCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuizzesCreationDto
     */
    name?: string | null;
}

/**
 * curquizzesUpdationDto
 * @export
 * @interface CurQuizzesUpdationDto
 */
export interface CurQuizzesUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQuizzesUpdationDto
     */
    name?: string | null;
} 