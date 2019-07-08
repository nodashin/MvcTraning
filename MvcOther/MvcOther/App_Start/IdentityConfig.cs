using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MvcOther.Models;

namespace MvcOther
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //// 電子メールを送信するには、電子メール サービスをここにプラグインします。
            //return Task.FromResult(0);

            //メール送信のための設定情報
            var smtp = "smpt.exsamples.com"; //SMTPサーバーのホスト名
            var port = 587;                  //ポート番号
            var userName = "userName";       //認証ユーザー名
            var password = "passwd";         //認証パスワード
            var from = "from@exsamples.com"; //送信元アドレス

            //メール送信の準備(コンストラクターの引数はSMTPサーバーのホスト名)
            var client = new SmtpClient(smtp)
            {
                Port = port,                                            //ポート番号
                DeliveryMethod = SmtpDeliveryMethod.Network,            //送付方法
                EnableSsl = false,                                      //SSLを利用するか
                UseDefaultCredentials = false,                          //規定の資格情報を利用するか
                Credentials = new NetworkCredential(userName, password) //認証情報
            };

            //指定されたメッセージを送信(コンストラクターの引数はFrom, To)
            return client.SendMailAsync(new MailMessage(from, message.Destination)
            {
                IsBodyHtml = true,         //HTMLメールとして送信するか
                Subject = message.Subject, //件名
                Body = message.Body        //本文
            });
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // テキスト メッセージを送信するための SMS サービスをここにプラグインします。
            return Task.FromResult(0);
        }
    }

    // このアプリケーションで使用されるアプリケーション ユーザー マネージャーを設定します。UserManager は ASP.NET Identity の中で定義されており、このアプリケーションで使用されます。
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            //ApplicationUserManagerオブジェクトをインスタンス化
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            manager.UserLockoutEnabledByDefault = true;
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);

            //ユーザー名の検証ルール
            // ユーザー名の検証ロジックを設定します
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            //パスワードの検証ルール
            // パスワードの検証ロジックを設定します
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // ユーザー ロックアウトの既定値を設定します。
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // 2 要素認証プロバイダーを登録します。このアプリケーションでは、Phone and Emails をユーザー検証用コード受け取りのステップとして使用します。
            // 独自のプロバイダーをプログラミングしてここにプラグインできます。
            manager.RegisterTwoFactorProvider("電話コード", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "あなたのセキュリティ コードは {0} です。"
            });
            manager.RegisterTwoFactorProvider("電子メール コード", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "セキュリティ コード",
                BodyFormat = "あなたのセキュリティ コードは {0} です。"
            });

            //メール送信のための設定
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // このアプリケーションで使用されるアプリケーション サインイン マネージャーを構成します。
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
