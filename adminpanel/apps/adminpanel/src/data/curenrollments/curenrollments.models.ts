import { BaseEntity } from "@dkd-query";



/**
 * curenrollmentsDto
 * @export
 * @interface CurEnrollmentsDto
 */
export interface CurEnrollmentsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurEnrollmentsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurEnrollmentsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurEnrollmentsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurEnrollmentsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurEnrollmentsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurEnrollmentsDto
     */
    name?: string | null;

}

/**
 * curenrollmentsDto
 * @export
 * @interface CurEnrollmentsCreationDto
 */
export interface CurEnrollmentsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurEnrollmentsCreationDto
     */
    name?: string | null;
}

/**
 * curenrollmentsUpdationDto
 * @export
 * @interface CurEnrollmentsUpdationDto
 */
export interface CurEnrollmentsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurEnrollmentsUpdationDto
     */
    name?: string | null;
} 