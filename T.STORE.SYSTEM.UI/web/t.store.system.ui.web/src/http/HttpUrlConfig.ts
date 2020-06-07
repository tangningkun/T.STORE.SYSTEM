/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-05-28 23:50:41
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-08 00:04:59
 */
import { Injectable } from '@vue-ioc/core';

@Injectable()
export class HttpUrlConfig {
  public constructor() {}
  public getRouteUrl() {
    return '/static/Json/route.json';
  }
  public getTestXml() {
    return '/static/xml/test.xml';
  }
}
