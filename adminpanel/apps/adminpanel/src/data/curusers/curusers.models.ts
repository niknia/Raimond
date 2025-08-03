import { BaseEntity } from "@dkd-query";



/**
 * curusersDto
 * @export
 * @interface CurUsersDto
 */
export interface CurUsersDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurUsersDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurUsersDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurUsersDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurUsersDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurUsersDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurUsersDto
     */
    name?: string | null;

}

/**
 * curusersDto
 * @export
 * @interface CurUsersCreationDto
 */
export interface CurUsersCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurUsersCreationDto
     */
    name?: string | null;
}

/**
 * curusersUpdationDto
 * @export
 * @interface CurUsersUpdationDto
 */
export interface CurUsersUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurUsersUpdationDto
     */
    name?: string | null;
} 