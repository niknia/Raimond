import type { MenuItem } from '../types/menuItems';

export const menuItems: MenuItem[] = [
  {
    id: 149,
    parentId: null,
    code: "Raimond-base",
    pCode: "gatarbar",
    path: "/plan-base",
    component: "layout",
    name: "اطلاعات پایه",
    ordinal: 1,
    hidden: false,
    meta: {
      title: "Raimond-base",
      icon: "settings"
    },
    children: [
      {
        id: 154,
        parentId: 149,
        code: "companyGroup",
        pCode: "Raimond-base",
        path: "/WbmStation",
        component: "layout",
        name: "گروه بندی شرکتها",
        ordinal: 1,
        hidden: false,
        meta: {
          title: "companyGroup",
          icon: "building"
        },
        children: []
      },
      {
        id: 153,
        parentId: 149,
        code: "Messages",
        pCode: "Raimond-base",
        path: "/plan-base",
        component: "layout",
        name: "پیغام ها",
        ordinal: 1,
        hidden: false,
        meta: {
          title: "Messages",
          icon: "message"
        },
        children: []
      },
      {
        id: 152,
        parentId: 149,
        code: "Information",
        pCode: "Raimond-base",
        path: "/plan-base",
        component: "layout",
        name: "اطلاعیه ها",
        ordinal: 1,
        hidden: false,
        meta: {
          title: "Information",
          icon: "info"
        },
        children: []
      },
      {
        id: 155,
        parentId: 149,
        code: "companyGroup",
        pCode: "Raimond-base",
        path: "/plan-base",
        component: "layout",
        name: "مراکز آموزشی",
        ordinal: 1,
        hidden: false,
        meta: {
          title: "companyGroup",
          icon: "screen-users"
        },
        children: []
      },
      {
        id: 157,
        parentId: 149,
        code: "Teacher",
        pCode: "Raimond-base",
        path: "/plan-base",
        component: "layout",
        name: "مدرسان",
        ordinal: 1,
        hidden: false,
        meta: {
          title: "Teacher",
          icon: "chalkboard-user"
        },
        children: []
      },
      {
        id: 158,
        parentId: 149,
        code: "FreeUser",
        pCode: "Raimond-base",
        path: "base-info/SfrCity/list",
        component: "base-info/SfrCity/list",
        name: "فراگیران آزاد",
        ordinal: 1,
        hidden: false,
        meta: {
          title: "FreeUser",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 162,
        parentId: 149,
        code: "Proviance",
        pCode: "Raimond-base",
        path: "base-info/SfrProvince/list",
        component: "base-info/Proviance/list",
        name: "اطالعات استانها",
        ordinal: 3,
        hidden: false,
        meta: {
          title: "Proviance",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 163,
        parentId: 149,
        code: "SfrCity",
        pCode: "Raimond-base",
        path: "base-info/SfrCity/list",
        component: "base-info/SfrCity/list",
        name: "اطلاعات شهرها",
        ordinal: 4,
        hidden: false,
        meta: {
          title: "SfrCity",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 164,
        parentId: 149,
        code: "courses",
        pCode: "Raimond-base",
        path: "base-info/courses/list",
        component: "base-info/courses/list",
        name: "اطلاعات دوره ها",
        ordinal: 5,
        hidden: false,
        meta: {
          title: "courses",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 165,
        parentId: 149,
        code: "specializations",
        pCode: "Raimond-base",
        path: "base-info/specializations/list",
        component: "base-info/specializations/list",
        name: "حوزه‌ها",
        ordinal: 6,
        hidden: false,
        meta: {
          title: "specializations",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 166,
        parentId: 149,
        code: "course_types",
        pCode: "Raimond-base",
        path: "base-info/course_types/list",
        component: "base-info/course_types/list",
        name: "نوع دوره",
        ordinal: 7,
        hidden: false,
        meta: {
          title: "course_types",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 167,
        parentId: 149,
        code: "qualifications",
        pCode: "Raimond-base",
        path: "base-info/qualifications/list",
        component: "base-info/qualifications/list",
        name: "تحصیلات",
        ordinal: 8,
        hidden: false,
        meta: {
          title: "qualifications",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 168,
        parentId: 149,
        code: "qualifications",
        pCode: "Raimond-base",
        path: "base-info/course_contents/list",
        component: "base-info/course_contents/list",
        name: "سرفصل‌های",
        ordinal: 9,
        hidden: false,
        meta: {
          title: "qualifications",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 169,
        parentId: 149,
        code: "course_objectives",
        pCode: "Raimond-base",
        path: "base-info/course_objectives/list",
        component: "base-info/course_objectives/list",
        name: "اهداف رفتاری",
        ordinal: 10,
        hidden: false,
        meta: {
          title: "course_objectives",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 170,
        parentId: 149,
        code: "related_jobs",
        pCode: "Raimond-base",
        path: "base-info/related_jobs/list",
        component: "base-info/related_jobs/list",
        name: "مشاغل",
        ordinal: 11,
        hidden: false,
        meta: {
          title: "related_jobs",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 171,
        parentId: 149,
        code: "teaching_methods",
        pCode: "Raimond-base",
        path: "base-info/teaching_methods/list",
        component: "base-info/teaching_methods/list",
        name: "روش‌های برگزاری",
        ordinal: 12,
        hidden: false,
        meta: {
          title: "teaching_methods",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 172,
        parentId: 149,
        code: "course_standards",
        pCode: "Raimond-base",
        path: "base-info/course_standards/list",
        component: "base-info/course_standards/list",
        name: "استانداردهای دوره",
        ordinal: 13,
        hidden: false,
        meta: {
          title: "course_standards",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 173,
        parentId: 149,
        code: "teachers",
        pCode: "Raimond-base",
        path: "base-info/teachers/list",
        component: "base-info/teachers/list",
        name: "مدرس",
        ordinal: 14,
        hidden: false,
        meta: {
          title: "teachers",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 174,
        parentId: 149,
        code: "cur_religions",
        pCode: "Raimond-base",
        path: "base-info/cur_religions/list",
        component: "base-info/cur_religions/list",
        name: "مذهب",
        ordinal: 15,
        hidden: false,
        meta: {
          title: "cur_religions",
          icon: "person-chalkboard"
        },
        children: []
      },
      {
        id: 175,
        parentId: 149,
        code: "cur_denominations",
        pCode: "Raimond-base",
        path: "base-info/cur_denominations/list",
        component: "base-info/cur_denominations/list",
        name: "دین",
        ordinal: 16,
        hidden: false,
        meta: {
          title: "cur_denominations",
          icon: "person-chalkboard"
        },
        children: []
      }
    ]
  }
];
