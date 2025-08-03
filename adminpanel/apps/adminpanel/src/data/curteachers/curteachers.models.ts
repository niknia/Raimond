import { BaseEntity } from "@dkd-query";

/**
 * curteachersDto
 * @export
 * @interface CurTeachersDto
 */
export interface CurTeachersDto extends BaseEntity  {
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    id: number;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    createBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    createTime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    modifyBy?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    modifyTime?: string;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    address?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    birthDate?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    birthPlace?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    createby?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    createdAt?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    createtime?: string;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    degreeId?: number;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    denominationId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    fatherName?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    fieldOfStudyId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    firstName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    gender?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    idIssuePlace?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    idNumber?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof CurTeachersDto
     */
    isAcademicMember?: boolean | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    lastName?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    maritalStatusId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    militaryStatus?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    modifyby?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    modifytime?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    nationalCode?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    phoneLandline?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    phoneMobile?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    postalCode?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    religionId?: number | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersDto
     */
    teacherTypeId?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersDto
     */
    updatedAt?: string | null;
    /**
     * 
     * @type {object}
     * @memberof CurTeachersDto
     */
    curReligions?: object;
    /**
     * 
     * @type {object}
     * @memberof CurTeachersDto
     */
    curDenominations?: object;
    /**
     * 
     * @type {object}
     * @memberof CurTeachersDto
     */
    curMaritalStatuses?: object;
    /**
     * 
     * @type {object}
     * @memberof CurTeachersDto
     */
    curTeacherTypes?: object;
    /**
     * 
     * @type {object}
     * @memberof CurTeachersDto
     */
    curDegrees?: object;
    /**
     * 
     * @type {CurFieldsOfStudyDto}
     * @memberof CurTeachersDto
     */
}

/**
 * curteachersDto
 * @export
 * @interface CurTeachersCreationDto
 */
export interface CurTeachersCreationDto {
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    address?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    birthDate?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    birthPlace?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    createdAt?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersCreationDto
     */
    degreeId?: number;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersCreationDto
     */
    denominationId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    fatherName?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersCreationDto
     */
    fieldOfStudyId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    firstName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    gender?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    idIssuePlace?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    idNumber?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof CurTeachersCreationDto
     */
    isAcademicMember?: boolean | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    lastName?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersCreationDto
     */
    maritalStatusId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    militaryStatus?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    nationalCode?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    phoneLandline?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    phoneMobile?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    postalCode?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersCreationDto
     */
    religionId?: number | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersCreationDto
     */
    teacherTypeId?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersCreationDto
     */
    updatedAt?: string | null;
}

/**
 * curteachersUpdationDto
 * @export
 * @interface CurTeachersUpdationDto
 */
export interface CurTeachersUpdationDto {
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    address?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    birthDate?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    birthPlace?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    createdAt?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersUpdationDto
     */
    degreeId?: number;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersUpdationDto
     */
    denominationId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    fatherName?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersUpdationDto
     */
    fieldOfStudyId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    firstName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    gender?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    idIssuePlace?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    idNumber?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof CurTeachersUpdationDto
     */
    isAcademicMember?: boolean | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    lastName?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersUpdationDto
     */
    maritalStatusId?: number | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    militaryStatus?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    nationalCode?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    phoneLandline?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    phoneMobile?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    postalCode?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersUpdationDto
     */
    religionId?: number | null;
    /**
     * 
     * @type {number}
     * @memberof CurTeachersUpdationDto
     */
    teacherTypeId?: number;
    /**
     * 
     * @type {string}
     * @memberof CurTeachersUpdationDto
     */
    updatedAt?: string | null;
}

