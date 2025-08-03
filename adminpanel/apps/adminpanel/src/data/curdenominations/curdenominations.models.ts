import { BaseEntity } from "@dkd-query";



/**
 * curdenominationsDto
 * @export
 * @interface CurDenominationsDto
 */
export interface CurDenominationsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurDenominationsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurDenominationsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurDenominationsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurDenominationsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurDenominationsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurDenominationsDto
     */
    name?: string | null;

}

/**
 * curdenominationsDto
 * @export
 * @interface CurDenominationsCreationDto
 */
export interface CurDenominationsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurDenominationsCreationDto
     */
    name?: string | null;
}

/**
 * curdenominationsUpdationDto
 * @export
 * @interface CurDenominationsUpdationDto
 */
export interface CurDenominationsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurDenominationsUpdationDto
     */
    name?: string | null;
} 