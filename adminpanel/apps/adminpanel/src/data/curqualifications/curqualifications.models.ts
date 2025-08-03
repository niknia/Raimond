import { BaseEntity } from "@dkd-query";



/**
 * curqualificationsDto
 * @export
 * @interface CurQualificationsDto
 */
export interface CurQualificationsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurQualificationsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurQualificationsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQualificationsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurQualificationsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurQualificationsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurQualificationsDto
     */
    name?: string | null;

}

/**
 * curqualificationsDto
 * @export
 * @interface CurQualificationsCreationDto
 */
export interface CurQualificationsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQualificationsCreationDto
     */
    name?: string | null;
}

/**
 * curqualificationsUpdationDto
 * @export
 * @interface CurQualificationsUpdationDto
 */
export interface CurQualificationsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurQualificationsUpdationDto
     */
    name?: string | null;
} 