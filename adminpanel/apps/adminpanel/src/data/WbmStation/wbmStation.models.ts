import { BaseEntity, ResultPage } from "@dkd-query";



export type SfrOwnerResultPage = ResultPage<WbmStationDto[]>;
/**
 * wbmstationDto
 * @export
 * @interface WbmStationDto
 */
export interface WbmStationDto extends BaseEntity{
    /**
     * 
     * @type {number}
     * @memberof WbmStationDto
     */
    'id': number;
    /**
     * 
     * @type {number}
     * @memberof WbmStationDto
     */
    'createBy'?: number;
    /**
     * 
     * @type {string}
     * @memberof WbmStationDto
     */
    'createTime'?: string;
    /**
     * 
     * @type {number}
     * @memberof WbmStationDto
     */
    'modifyBy'?: number;
    /**
     * 
     * @type {string}
     * @memberof WbmStationDto
     */
    'modifyTime'?: string;
    /**
     * 
     * @type {number}
     * @memberof WbmStationDto
     */
    'trainCode'?: number | null;
    /**
     * 
     * @type {boolean}
     * @memberof WbmStationDto
     */
    'showTrainCode'?: boolean | null;
    /**
     * 
     * @type {string}
     * @memberof WbmStationDto
     */
    'nameFa'?: string | null;
    /**
     * 
     * @type {string}
     * @memberof WbmStationDto
     */
    'nameEn'?: string | null;
    /**
     * فرودگاه
     * @type {boolean}
     * @memberof WbmStationDto
     */
    'isAirport'?: boolean | null;
    /**
     * 
     * @type {number}
     * @memberof WbmStationDto
     */
    'orderstation'?: number | null;
}

/**
 * wbmstationDto
 * @export
 * @interface WbmStationCreationDto
 */
export interface WbmStationCreationDto {
    /**
     * 
     * @type {number}
     * @memberof WbmStationCreationDto
     */
    'trainCode'?: number | null;
    /**
     * 
     * @type {boolean}
     * @memberof WbmStationCreationDto
     */
    'showTrainCode'?: boolean | null;
    /**
     * 
     * @type {string}
     * @memberof WbmStationCreationDto
     */
    'nameFa'?: string | null;
    /**
     * 
     * @type {string}
     * @memberof WbmStationCreationDto
     */
    'nameEn'?: string | null;
    /**
     * فرودگاه
     * @type {boolean}
     * @memberof WbmStationCreationDto
     */
    'isAirport'?: boolean | null;
    /**
     * 
     * @type {number}
     * @memberof WbmStationCreationDto
     */
    'orderstation'?: number | null;
}

/**
 * wbmstationUpdationDto
 * @export
 * @interface WbmStationUpdationDto
 */
export interface WbmStationUpdationDto {
    /**
     * 
     * @type {number}
     * @memberof WbmStationUpdationDto
     */
    'trainCode'?: number | null;
    /**
     * 
     * @type {boolean}
     * @memberof WbmStationUpdationDto
     */
    'showTrainCode'?: boolean | null;
    /**
     * 
     * @type {string}
     * @memberof WbmStationUpdationDto
     */
    'nameFa'?: string | null;
    /**
     * 
     * @type {string}
     * @memberof WbmStationUpdationDto
     */
    'nameEn'?: string | null;
    /**
     * فرودگاه
     * @type {boolean}
     * @memberof WbmStationUpdationDto
     */
    'isAirport'?: boolean | null;
    /**
     * 
     * @type {number}
     * @memberof WbmStationUpdationDto
     */
    'orderstation'?: number | null;
}

