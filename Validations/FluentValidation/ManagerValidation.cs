using Common.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Manage.FluentValidation
{
  public  class ManagerValidation : AbstractValidator<Manager>
    {
      
        public ManagerValidation()
        {
            RuleFor(x => x.ID).NotNull().GreaterThan(0).WithMessage("用户信息获取异常");
         
            RuleFor(x => x.RealName).NotNull().WithMessage("管理员姓名不能为空").MaximumLength(50).WithMessage("最大长度为50个字符");
            RuleFor(x => x.ManagerAccount).NotNull().WithMessage("管理员账号不能为空");
            RuleFor(x => x.ManagerPwd).NotNull().WithMessage("管理员原密码不能为空");
            RuleFor(x => x.ManagerPwd).NotEmpty().Length(6, 32).WithMessage("原密码不能为空且长度必须符合规则(大于等于6位字符并且小于32位字符)");
            RuleFor(x => x.RoleID).NotNull().GreaterThan(0).WithMessage("请选择管理员所属角色");
            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("电子邮箱不能为空.").EmailAddress().WithMessage("电子邮箱格式不正确");
            RuleFor(x => x.Telephone).Must(BeAValidPostcode).When(x=>!string.IsNullOrWhiteSpace(x.Telephone))
               .WithMessage("手机格式不正确");
            //RuleFor(x => x.Telephone)
            //   .PhoneNumber().When(m => !string.IsNullOrWhiteSpace(m.Email)).WithMessage("手机格式不正确");
        }
        private bool BeAValidPostcode(string postcode)
        {
            //var RegexHelper2 = new ();
            return RegexHelper.IsMobile(postcode);
        }

    }
}
