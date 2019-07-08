namespace MvcModel.Migrations
{
  using MvcModel.Models;
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<MvcModel.Models.MvcModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcModel.Models.MvcModelContext";
        }

        protected override void Seed(MvcModel.Models.MvcModelContext context)
        {
          var article1 = new Article
          {            
            Url = "http://www.buildinsider.net/web/jquerymobileref",
            Title = "jQuery Mobile�t�������t�@�����X",
            Category = CategoryEnum.Reference,
            Description = "jQuery Mobile�̊�{�@�\��ړI�ʃ��t�@�����X�̌`���ł܂Ƃ߂܂��B",
            Viewcount = 36452,
            Published = DateTime.Parse("2014-01-09"),
            Released = true
          };
          var article2 = new Article
          {
            Url = "http://codezine.jp/article/corner/518",
            Title = "Bootstrap�Ń��X�|���V�u�Ń��b�`�ȃT�C�g���\�z",
            Category = CategoryEnum.Cloud,
            Description = "ASP.NET MVC5�̂ЂȌ`�y�[�W�Ŏg�p����Ă���Bootstrap�Ƃ����t���[�����[�N�ɂ��ďЉ�܂��B",
            Viewcount = 9312,
            Published = DateTime.Parse("2014-05-22"),
            Released = true
          };
          var article3 = new Article
          {
            Url = "http://codezine.jp/article/corner/511",
            Title = "ASP.NET Identity����",
            Category = CategoryEnum.DotNet,
            Description = "�V�����F�؁A���i�Ǘ��V�X�e���ł���uASP.NET Identity�v�ɂ��āA�ǂ̂悤�Ɏg���̂��A�ǂ�Ȏd�g�݂œ����Ă���̂����Љ�Ă����܂��B",
            Viewcount = 8046,
            Published = DateTime.Parse("2014-04-18"),
            Released = true
          };
          var article4 = new Article
          {
            Url = "http://codezine.jp/article/corner/513",
            Title = "Amazon Web Services�ɂ��N���E�h������",
            Category = CategoryEnum.Cloud,
            Description = "Amazon Web Services���g���ăN���E�h�V�X�e����ɊȒP��Web�V�X�e�����\�z���Ă����܂��B",
            Viewcount = 25687,
            Published = DateTime.Parse("2014-04-25"),
            Released = true
          };
          var article5 = new Article
          {
            Url = "http://www.buildinsider.net/web/jqueryuiref",
            Title = "jQuery UI�t�������t�@�����X",
            Category = CategoryEnum.Reference,
            Description = "jQuery UI�̊�{�@�\��ړI�ʃ��t�@�����X�̌`���ł܂Ƃ߂܂��B",
            Viewcount = 56710,
            Published = DateTime.Parse("2013-07-11"),
            Released = true
          };
          context.Articles.AddOrUpdate(a => a.Url, article1, article2, article3, article4, article5);

          var comment = new Comment
          {
            Name = "����q",
            Body = "�ړI�ʂŒT���₷���d�󂵂Ă��܂��B",
            Updated = DateTime.Parse("2014-06-01"),
            Article = article1
          };
          var comment2 = new Comment
          {
            Name = "�a�c�đ�",
            Body = "���Ⴊ�ڂ��Ă���̂ł킩��₷���Ǝv���܂��B",
            Updated = DateTime.Parse("2014-06-11"),
            Article = article1
          };
          var comment3 = new Comment
          {
            Name = "�c���O�Y",
            Body = "�܂Ƃߕ����ǂ��Ă킩��₷�������ł��B",
            Updated = DateTime.Parse("2014-06-15"),
            Article = article2
          };
          context.Comments.AddOrUpdate( c => c.Body, comment, comment2, comment3);

          var author1 = new Author
          {
            Name = "�R�c���Y",
            Email = "taro@wings.msn.to",
            Birth = DateTime.Parse("1970-12-10"),
            Articles = new List<Article> { article1, article2, article3, article5 }
          };
          var author2 = new Author
          {
            Name = "��؋v��",
            Email = "kumi@wings.msn.to",
            Birth = DateTime.Parse("1985-11-12"),
            Articles = new List<Article> { article1, article4 }
          };
          var author3 = new Author
          {
            Name = "�����q�v",
            Email = "toshi@wings.msn.to",
            Birth = DateTime.Parse("1975-05-26"),
            Articles = new List<Article> { article1, article2 }
          };
          context.Authors.AddOrUpdate(au => au.Email, author1, author2, author3);

          var member1 = new Member
          {
            Name = "�R�c���I",
            Email = "rio@wings.msn.to",
            Birth = DateTime.Parse("1980-06-25"),
            Married = false,
            Memo = "�s�A�m����D���ł��B"
          };
          var member2 = new Member
          {
            Name = "�������O",
            Email = "naohiro@wings.msn.to",
            Birth = DateTime.Parse("1975-07-19"),
            Married = false,
            Memo = "�q�ǂ��ɂ��₳��������҂���ł��B"
          };
          var member3 = new Member
          {
            Name = "�|�J�ޔ�",
            Email = "nami@wings.msn.to",
            Birth = DateTime.Parse("1985-08-05"),
            Married = false,
            Memo = "�t�����[�A�����W�����g��׋����ł��B"
          };
          var member4 = new Member
          {
            Name = "�ؑ����Y",
            Email = "jiro@wings.msn.to",
            Birth = DateTime.Parse("1970-12-15"),
            Married = true,
            Memo = "�R�o�肪��ł��B�x���́A�悭�R�֏o�����܂��B"
          };
          var member5 = new Member
          {
            Name = "��،b�q",
            Email = "keiko@wings.msn.to",
            Birth = DateTime.Parse("1984-11-23"),
            Married = true,
            Memo = "�q�ǂ��ƈꏏ�ɃA�j��������̂���D���ł��B"
        };
          context.Members.AddOrUpdate(m => m.Email, member1, member2, member3, member4, member5);

          context.SaveChanges();
        }
    }
}
