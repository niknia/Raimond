import { BaseEntity } from "@dkd-query";



/**
 * curteachingmethodsDto
 * @export
 * @interface CurTeachingMethodsDto
 */
export interface CurTeachingMethodsDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurTeachingMethodsDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurTeachingMethodsDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachingMethodsDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurTeachingMethodsDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachingMethodsDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurTeachingMethodsDto
     */
    name?: string | null;

}

/**
 * curteachingmethodsDto
 * @export
 * @interface CurTeachingMethodsCreationDto
 */
export interface CurTeachingMethodsCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurTeachingMethodsCreationDto
     */
    name?: string | null;
}

/**
 * curteachingmethodsUpdationDto
 * @export
 * @interface CurTeachingMethodsUpdationDto
 */
export interface CurTeachingMethodsUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurTeachingMethodsUpdationDto
     */
    name?: string | null;
} 