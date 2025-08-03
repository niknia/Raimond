import { BaseEntity } from "@dkd-query";



/**
 * curlrslogsDto
 * @export
 * @interface CurLrslogsDto
 */
export interface CurLrslogsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurLrslogsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurLrslogsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurLrslogsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurLrslogsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurLrslogsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurLrslogsDto
     */
    name?: string | null;

}

/**
 * curlrslogsDto
 * @export
 * @interface CurLrslogsCreationDto
 */
export interface CurLrslogsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurLrslogsCreationDto
     */
    name?: string | null;
}

/**
 * curlrslogsUpdationDto
 * @export
 * @interface CurLrslogsUpdationDto
 */
export interface CurLrslogsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurLrslogsUpdationDto
     */
    name?: string | null;
} 