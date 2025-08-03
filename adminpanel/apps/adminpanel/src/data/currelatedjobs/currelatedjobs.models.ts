import { BaseEntity } from "@dkd-query";



/**
 * currelatedjobsDto
 * @export
 * @interface CurRelatedjobsDto
 */
export interface CurRelatedjobsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurRelatedjobsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurRelatedjobsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurRelatedjobsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurRelatedjobsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurRelatedjobsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurRelatedjobsDto
     */
    name?: string | null;

}

/**
 * currelatedjobsDto
 * @export
 * @interface CurRelatedjobsCreationDto
 */
export interface CurRelatedjobsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurRelatedjobsCreationDto
     */
    name?: string | null;
}

/**
 * currelatedjobsUpdationDto
 * @export
 * @interface CurRelatedjobsUpdationDto
 */
export interface CurRelatedjobsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurRelatedjobsUpdationDto
     */
    name?: string | null;
} 