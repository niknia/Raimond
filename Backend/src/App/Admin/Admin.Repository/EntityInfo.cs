
namespace Dkd.App.Admin.Repository;

public class EntityInfo : AbstractEntityInfo
{
    protected override List<Assembly> GetEntityAssemblies() => [GetType().Assembly, typeof(EventTracker).Assembly];

    protected override void SetTableName(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SysEventtracker>().ToTable("sys_eventtracker");
        modelBuilder.Entity<SysOrganization>().ToTable("sys_organization");
        modelBuilder.Entity<SysMenu>().ToTable("sys_menu");
        modelBuilder.Entity<SysRole>().ToTable("sys_role");
        modelBuilder.Entity<SysUser>().ToTable("sys_user");
        modelBuilder.Entity<SysConfig>().ToTable("sys_config");
        modelBuilder.Entity<SysDictionary>().ToTable("sys_dictionary");
        modelBuilder.Entity<SysDictionaryData>().ToTable("sys_dictionary_data");
        modelBuilder.Entity<SysUserType>().ToTable(@"sys_UserType");

        modelBuilder.Entity<CurAnswers>().ToTable("cur_answers");
        modelBuilder.Entity<CurAssignments>().ToTable("cur_assignments");
        modelBuilder.Entity<CurAssignmentSubmissions>().ToTable("cur_assignment_submissions");
        modelBuilder.Entity<CurAttendances>().ToTable("cur_attendances");
        modelBuilder.Entity<CurClasses>().ToTable("cur_classes");
        modelBuilder.Entity<CurCourseContents>().ToTable("cur_course_contents");
        modelBuilder.Entity<CurCourses>().ToTable("cur_courses");
        modelBuilder.Entity<CurCourseStandards>().ToTable("cur_course_standards");
        modelBuilder.Entity<CurCourseTypes>().ToTable("cur_course_types");
        modelBuilder.Entity<CurDegrees>().ToTable("cur_degrees");
        modelBuilder.Entity<CurDenominations>().ToTable("cur_denominations");
        modelBuilder.Entity<CurEnrollments>().ToTable("cur_enrollments");
        modelBuilder.Entity<CurFieldsOfStudy>().ToTable("cur_fields_of_study");
        modelBuilder.Entity<CurLrsLogs>().ToTable("cur_lrs_logs");
        modelBuilder.Entity<CurMaritalStatuses>().ToTable("cur_marital_statuses");
        modelBuilder.Entity<CurOrganizations>().ToTable("cur_organizations");
        modelBuilder.Entity<CurQualifications>().ToTable("cur_qualifications");
        modelBuilder.Entity<CurQuestionAnswers>().ToTable("cur_question_answers");
        modelBuilder.Entity<CurQuestions>().ToTable("cur_questions");
        modelBuilder.Entity<CurQuizSubmissions>().ToTable("cur_quiz_submissions");
        modelBuilder.Entity<CurQuizzes>().ToTable("cur_quizzes");
        modelBuilder.Entity<CurRelatedJobs>().ToTable("cur_related_jobs");
        modelBuilder.Entity<CurReligions>().ToTable("cur_religions");
        modelBuilder.Entity<CurSchedules>().ToTable("cur_schedules");
        modelBuilder.Entity<CursCourseObjectives>().ToTable("curs_course_objectives"); // توجه: این یک اشتباه احتمالی در نام جدول است (curs به جای cur)
        modelBuilder.Entity<CurSpecializations>().ToTable("cur_specializations");
        modelBuilder.Entity<CurTeachers>().ToTable("cur_teachers");
        modelBuilder.Entity<CurTeacherTypes>().ToTable("cur_teacher_types");
        modelBuilder.Entity<CurTeachingMethods>().ToTable("cur_teaching_methods");
        modelBuilder.Entity<CurUsers>().ToTable("cur_users");

        //modelBuilder.Entity<Notice>().ToTable("sys_notice");
    }
}
