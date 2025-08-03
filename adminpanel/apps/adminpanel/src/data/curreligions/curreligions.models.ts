import { BaseEntity } from "@dkd-query";



/**
 * curreligionsDto
 * @export
 * @interface CurReligionsDto
 */
export interface CurReligionsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurReligionsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurReligionsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurReligionsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurReligionsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurReligionsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurReligionsDto
     */
    name?: string | null;

}

/**
 * curreligionsDto
 * @export
 * @interface CurReligionsCreationDto
 */
export interface CurReligionsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurReligionsCreationDto
     */
    name?: string | null;
}

/**
 * curreligionsUpdationDto
 * @export
 * @interface CurReligionsUpdationDto
 */
export interface CurReligionsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurReligionsUpdationDto
     */
    name?: string | null;
} 