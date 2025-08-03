import type { MenuItem } from '../types/menuItems';

export const menuItems: MenuItem[] = [
  {
    id: 149,
    parentId: null,
    code: "Raimond-base",
    pCode: "gatarbar",
    path: "/plan-base",
    component: "layout",
    name: "رایموند",
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
        id: 157,
        parentId: 149,
        code: "Teacher",
        pCode: "Raimond-base",
        path: "/Curteachers",
        component: "Curteachers",
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
          id: 165,
          parentId: 149,
          code: "specializations",
          pCode: "Raimond-base",
          path: "/Curspecializations",
          component: "Curspecializations",
          name: "حوزه‌ها",
          ordinal: 1,
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
          path: "/Curcoursetypes",
          component: "Curcoursetypes",
          name: "نوع دوره",
          ordinal: 2,
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
          path: "/Curqualifications",
          component: "Curqualifications",
          name: "تحصیلات",
          ordinal: 3,
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
          path: "/Curscourseobjectives",
          component: "Curscourseobjectives",
          name: "اهداف رفتاری",
          ordinal: 4,
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
          path: "/Currelatedjobs",
          component: "Currelatedjobs",
          name: "مشاغل",
          ordinal: 5,
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
          path: "/Curteachingmethods",
          component: "Curteachingmethods",
          name: "روش‌های برگزاری",
          ordinal: 6,
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
          path: "/Curcoursestandards",
          component: "Curcoursestandards",
          name: "استانداردهای دوره",
          ordinal: 7,
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
          path: "/Curteachers",
          component: "Curteachers",
          name: "مدرس",
          ordinal: 8,
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
          path: "/Curreligions",
          component: "Curreligions",
          name: "مذهب",
          ordinal: 9,
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
          path: "/Curdenominations",
          component: "Curdenominations",
          name: "دین",
          ordinal: 10,
          hidden: false,
          meta: {
            title: "cur_denominations",
            icon: "person-chalkboard"
          },
          children: []
        },
              {
          id: 176,
          parentId: 149,
          code: "cur_users",
          pCode: "Raimond-base",
          path: "/Curusers",
          component: "Curusers",
          name: "کاربران",
          ordinal: 11,
          hidden: false,
          meta: {
            title: "cur_users",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 177,
          parentId: 149,
          code: "cur_teacher_types",
          pCode: "Raimond-base",
          path: "/Curteachertypes",
          component: "Curteachertypes",
          name: "انواع مدرس",
          ordinal: 12,
          hidden: false,
          meta: {
            title: "cur_teacher_types",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 178,
          parentId: 149,
          code: "cur_schedules",
          pCode: "Raimond-base",
          path: "/Curschedules",
          component: "Curschedules",
          name: "برنامه‌ها",
          ordinal: 13,
          hidden: false,
          meta: {
            title: "cur_schedules",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 179,
          parentId: 149,
          code: "cur_quizzes",
          pCode: "Raimond-base",
          path: "/Curquizzes",
          component: "Curquizzes",
          name: "آزمون‌ها",
          ordinal: 14,
          hidden: false,
          meta: {
            title: "cur_quizzes",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 180,
          parentId: 149,
          code: "cur_quiz_submissions",
          pCode: "Raimond-base",
          path: "/Curquizsubmissions",
          component: "Curquizsubmissions",
          name: "ارسال‌های آزمون",
          ordinal: 15,
          hidden: false,
          meta: {
            title: "cur_quiz_submissions",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 181,
          parentId: 149,
          code: "cur_questions",
          pCode: "Raimond-base",
          path: "/Curquestions",
          component: "Curquestions",
          name: "سوالات",
          ordinal: 16,
          hidden: false,
          meta: {
            title: "cur_questions",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 182,
          parentId: 149,
          code: "cur_question_answers",
          pCode: "Raimond-base",
          path: "/Curquestionanswers",
          component: "Curquestionanswers",
          name: "پاسخ‌های سوالات",
          ordinal: 17,
          hidden: false,
          meta: {
            title: "cur_question_answers",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 183,
          parentId: 149,
          code: "cur_organizations",
          pCode: "Raimond-base",
          path: "/Curorganizations",
          component: "Curorganizations",
          name: "سازمان‌ها",
          ordinal: 18,
          hidden: false,
          meta: {
            title: "cur_organizations",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 184,
          parentId: 149,
          code: "cur_marital_statuses",
          pCode: "Raimond-base",
          path: "/Curmaritalstatuses",
          component: "Curmaritalstatuses",
          name: "وضعیت تاهل",
          ordinal: 19,
          hidden: false,
          meta: {
            title: "cur_marital_statuses",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 185,
          parentId: 149,
          code: "cur_lrs_logs",
          pCode: "Raimond-base",
          path: "/Curlrslogs",
          component: "Curlrslogs",
          name: "لاگ‌های LRS",
          ordinal: 20,
          hidden: false,
          meta: {
            title: "cur_lrs_logs",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 186,
          parentId: 149,
          code: "cur_fields_of_study",
          pCode: "Raimond-base",
          path: "/Curfieldsofstudy",
          component: "Curfieldsofstudy",
          name: "رشته‌های تحصیلی",
          ordinal: 21,
          hidden: false,
          meta: {
            title: "cur_fields_of_study",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 187,
          parentId: 149,
          code: "cur_enrollments",
          pCode: "Raimond-base",
          path: "/Curenrollments",
          component: "Curenrollments",
          name: "ثبت‌نام‌ها",
          ordinal: 22,
          hidden: false,
          meta: {
            title: "cur_enrollments",
            icon: "person-chalkboard"
          },
          children: []
        },
        {
          id: 188,
          parentId: 149,
          code: "cur_degrees",
          pCode: "Raimond-base",
          path: "/Curdegrees",
          component: "Curdegrees",
          name: "مدارک تحصیلی",
          ordinal: 23,
          hidden: false,
          meta: {
            title: "cur_degrees",
            icon: "person-chalkboard"
          },
          children: []
        }
    ]
  }
];
