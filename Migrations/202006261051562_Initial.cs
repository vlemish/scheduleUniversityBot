namespace scheduleUniversityBot_net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fridays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvenOrOdd = c.Int(nullable: false),
                        lectureTime = c.Time(nullable: false, precision: 7),
                        TypeOfLecture = c.String(nullable: false, maxLength: 9),
                        LectureId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.TeacherId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(maxLength: 100),
                        TypeOfExam = c.String(maxLength: 50),
                        CourseWork = c.String(),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Mondays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvenOrOdd = c.Int(nullable: false),
                        lectureTime = c.Time(nullable: false, precision: 7),
                        TypeOfLecture = c.String(nullable: false, maxLength: 9),
                        LectureId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Thursdays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvenOrOdd = c.Int(nullable: false),
                        lectureTime = c.Time(nullable: false, precision: 7),
                        TypeOfLecture = c.String(nullable: false, maxLength: 9),
                        LectureId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Tuesdays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvenOrOdd = c.Int(nullable: false),
                        lectureTime = c.Time(nullable: false, precision: 7),
                        TypeOfLecture = c.String(nullable: false, maxLength: 9),
                        LectureId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Wednesdays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvenOrOdd = c.Int(nullable: false),
                        lectureTime = c.Time(nullable: false, precision: 7),
                        TypeOfLecture = c.String(nullable: false, maxLength: 9),
                        LectureId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fridays", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Wednesdays", "TeacherId", "dbo.Subjects");
            DropForeignKey("dbo.Wednesdays", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Tuesdays", "TeacherId", "dbo.Subjects");
            DropForeignKey("dbo.Tuesdays", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Thursdays", "TeacherId", "dbo.Subjects");
            DropForeignKey("dbo.Thursdays", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Mondays", "TeacherId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Mondays", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Fridays", "TeacherId", "dbo.Subjects");
            DropIndex("dbo.Wednesdays", new[] { "TeacherId" });
            DropIndex("dbo.Tuesdays", new[] { "TeacherId" });
            DropIndex("dbo.Thursdays", new[] { "TeacherId" });
            DropIndex("dbo.Mondays", new[] { "TeacherId" });
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropIndex("dbo.Fridays", new[] { "TeacherId" });
            DropTable("dbo.Holidays");
            DropTable("dbo.Wednesdays");
            DropTable("dbo.Tuesdays");
            DropTable("dbo.Thursdays");
            DropTable("dbo.Teachers");
            DropTable("dbo.Mondays");
            DropTable("dbo.Subjects");
            DropTable("dbo.Fridays");
        }
    }
}
