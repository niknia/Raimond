import { BaseEntity } from "@dkd-query";



/**
 * curorganizationsDto
 * @export
 * @interface CurOrganizationsDto
 */
export interface CurOrganizationsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurOrganizationsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurOrganizationsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurOrganizationsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurOrganizationsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurOrganizationsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurOrganizationsDto
     */
    name?: string | null;

}

/**
 * curorganizationsDto
 * @export
 * @interface CurOrganizationsCreationDto
 */
export interface CurOrganizationsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurOrganizationsCreationDto
     */
    name?: string | null;
}

/**
 * curorganizationsUpdationDto
 * @export
 * @interface CurOrganizationsUpdationDto
 */
export interface CurOrganizationsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurOrganizationsUpdationDto
     */
    name?: string | null;
} 