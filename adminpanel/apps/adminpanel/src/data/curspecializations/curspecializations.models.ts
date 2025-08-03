import { BaseEntity } from "@dkd-query";



/**
 * curspecializationsDto
 * @export
 * @interface CurSpecializationsDto
 */
export interface CurSpecializationsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurSpecializationsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurSpecializationsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurSpecializationsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurSpecializationsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurSpecializationsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurSpecializationsDto
     */
    name?: string | null;

}

/**
 * curspecializationsDto
 * @export
 * @interface CurSpecializationsCreationDto
 */
export interface CurSpecializationsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurSpecializationsCreationDto
     */
    name?: string | null;
}

/**
 * curspecializationsUpdationDto
 * @export
 * @interface CurSpecializationsUpdationDto
 */
export interface CurSpecializationsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurSpecializationsUpdationDto
     */
    name?: string | null;
} 