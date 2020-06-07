/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-06-04 00:00:19
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-08 00:06:06
 */

import { HttpServices } from '@/http/HttpServices';
import { HttpUrlConfig } from '@/http/HttpUrlConfig';

import { Injectable } from '@vue-ioc/core';

@Injectable()
export class RouteService {
  public constructor(public httpServices: HttpServices, private httpUrlConfig: HttpUrlConfig) {}
  public GetRouteData(): Promise<any> {
    return new Promise((resolve, reject) => {
      // 一段耗时的异步操作
      resolve('成功'); // 数据处理完成
      // reject('失败') // 数据处理出错
    }).then(
      (res) => {
        console.log(res);
        return res;
      }, // 成功
      (err) => {
        console.log(err);
      } // 失败
    );
  }
  public GetRouteData1(): Promise<any> {
    let url = this.httpUrlConfig.getRouteUrl();
    return this.httpServices
      .httpGetNoAuth(url)
      .then((res: any) => {
        return res;
        console.log(res);
      })
      .catch((err: any) => {
        console.log(err);
      });
  }
}
