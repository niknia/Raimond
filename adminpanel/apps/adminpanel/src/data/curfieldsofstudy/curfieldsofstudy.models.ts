import { BaseEntity } from "@dkd-query";



/**
 * curfieldsofstudyDto
 * @export
 * @interface CurFieldsofstudyDto
 */
export interface CurFieldsofstudyDto extends BaseEntity {
    /**
     * 
     * @type {number}
     * @memberof CurFieldsofstudyDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurFieldsofstudyDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurFieldsofstudyDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurFieldsofstudyDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurFieldsofstudyDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurFieldsofstudyDto
     */
    name?: string | null;

}

/**
 * curfieldsofstudyDto
 * @export
 * @interface CurFieldsofstudyCreationDto
 */
export interface CurFieldsofstudyCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurFieldsofstudyCreationDto
     */
    name?: string | null;
}

/**
 * curfieldsofstudyUpdationDto
 * @export
 * @interface CurFieldsofstudyUpdationDto
 */
export interface CurFieldsofstudyUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurFieldsofstudyUpdationDto
     */
    name?: string | null;
} 