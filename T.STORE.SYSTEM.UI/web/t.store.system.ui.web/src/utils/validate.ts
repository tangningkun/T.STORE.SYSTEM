// /*
//  * @Descripttion:
//  * @version: 1.0
//  * @Author: 唐宁坤
//  * @Date: 2020-06-02 00:13:29
//  * @LastEditors: 唐宁坤
//  * @LastEditTime: 2020-06-02 00:26:48
//  */
// export class Validate {
//   private reg: any;
//   private validator = {
//     // 验证失败后的提示
//     messages: {
//       notnull: '请输入{0}',
//       max: '长度最多为 {1} 个字符',
//       min: '长度最小为 {1} 个字符',
//       length: '{0}的长度在 {1} 到 {2} 个字符',
//       number: '{0}必须是数字',
//       string: '{0}必须是字母或者数字',
//       moblie: '{0}必须是手机或者电话号码格式',
//       phone: '{0}格式不正确',
//       noChinese: '{0}不能为中文',
//       lon: '{0}范围为-180.0～+180.0（必须输入1到10位小数）',
//       lat: '{0}范围为-90.0～+90.0（必须输入1到10位小数）',
//       url: '请输入正确的{0}访问地址',
//       repeat: '两次输入的{0}不一致',
//       email: '邮箱格式不正确',
//       password: '请输入由大小写字母+数字组成的6-16位密码',
//       fixedNum: '请输入{1}位数字',
//     },
//     // 验证的方法, 返回一个布尔值
//     methods:{
//       notnull: (obj: any) => {
//         return obj.value || obj.value === 0;
//       },
//       max: (obj: any) => {
//         if (!obj.value) return true;
//         return obj.conditions[0] >= obj.value.length;
//       },
//       min: (obj: any) => {
//         if (!obj.value) return true;
//         return obj.value.length >= obj.conditions[0];
//       },
//       length: (obj: any) => {
//         if (!obj.value) return true;
//         return obj.conditions[0] <= obj.value.length && obj.value.length <= obj.conditions[1];
//       },
//       number: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^[0-9]*\.?[0-9]*$/;
//         return this.reg.test(obj.value);
//       },
//       string: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^[a-zA-Z0-9]*$/;
//         return this.reg.test(obj.value);
//       },
//       moblie: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^(1[3,5,8,7]{1}[\d]{9})|(((400)-(\d{3})-(\d{4}))|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{3,7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)$/;
//         return this.reg.test(obj.value);
//       },
//       phone: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^1[3,5,8,7]{1}[\d]{9}$/;
//         return this.reg.test(obj.value);
//       },
//       noChinese: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /[\u4e00-\u9fa5]/;
//         return !this.reg.test(obj.value);
//       },
//       lon: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^[\-\+]?(0?\d{1,2}\.\d{1,10}|1[0-7]?\d{1}\.\d{1,10}|180\.0{1,10})$/;
//         return this.reg.test(obj.value);
//       },
//       lat: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^[\-\+]?([0-8]?\d{1}\.\d{1,10}|90\.0{1,10})$/;
//         return this.reg.test(obj.value);
//       },
//       url: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^([hH][tT]{2}[pP]:\/\/|[hH][tT]{2}[pP][sS]:\/\/)(([A-Za-z0-9-~]+)\.)+([A-Za-z0-9-~\/])+$/;
//         return this.reg.test(obj.value);
//       },
//       repeat: (obj: any) => {
//         if (!obj.value) return true;
//         return obj.value === obj.value1;
//       },
//       email: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^([-_A-Za-z0-9\.]+)@([_A-Za-z0-9]+\.)+[A-Za-z0-9]{2,3}$/;
//         return this.reg.test(obj.value);
//       },
//       password: (obj: any) => {
//         if (!obj.value) return true;
//         this.reg = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{6,16}$/;
//         return this.reg.test(obj.value);
//       },
//       fixedNum: (obj: any) => {
//         if (!obj.value) return true;
//         return obj.value.length === obj.conditions[0];
//       },
//     },
//   };
//   public checkResult = (obj: any) => {
//     let checkType;
//     let result = true;
//     let message = '验证成功';
//     let validatorMethods = this.validator.methods;
//     let validatorMessage = this.validator.messages;
//     // 循环验证
//     for (let i = 0, len = obj.rules.length; i < len; i++) {
//       // 当验证的规则不存在，默认跳过这个验证
//       if (!validatorMethods[obj.rules[i]]) {
//         // console.log(obj.rules[i] + '规则不存在');
//         break;
//       }
//       // 得到当前验证失败信息
//       if (!validatorMethods[obj.rules[i]](obj: any)) {
//         checkType = obj.rules[i];
//         result = false;
//         break;
//       }
//     }
//     // 如果验证失败, 得到验证失败的结果集
//     if (!result) {
//       message = validatorMessage[checkType];
//       if (obj.conditions) {
//         obj.conditions.forEach((item:any, index:number) => {
//           message = message.replace('{' + (index + 1) + '}', item);
//         });
//       }
//       message = message.replace('{0}', obj.label);
//       return { result, message };
//     }

//     return { result, message };
//   };
// }
