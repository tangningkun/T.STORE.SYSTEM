/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-05-28 23:15:16
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-08 00:04:50
 */

import Axios from 'axios';
import Interceptors from './interceptors';
import { HttpUrlConfig } from './HttpUrlConfig';
declare var X2JS: any;
import { Injectable } from '@vue-ioc/core';

@Injectable()
export class HttpServices {
  public constructor() {}
  /**
   * @Author: 唐宁坤
   * @Date: 2020-05-31 01:32:49
   * @Descripttion: 将返回的XML数据转为JSON数据
   */
  public httpGetNoAuthXml(url: string): Promise<any> {
    return Axios.get(url, {
      headers: {
        'Content-Type': 'text/html',
      },
    })
      .then((response) => {
        console.log(response);
        let x2js = new X2JS();
        return x2js.xml_str2json(response.data);
      })
      .catch((err) => {
        return err;
      });
  }
  /**
   * @Author: 唐宁坤
   * @Date: 2020-05-31 01:33:53
   * @Descripttion:
   */
  public httpPostNoAuthXml(url: string, body: any): Promise<any> {
    return Axios({
      method: 'POST',
      data: body,
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8',
      },
      url,
    })
      .then((response) => {
        console.log(response);
        let x2js = new X2JS();
        let temp = x2js.xml_str2json(response.data);
        temp = x2js.xml_str2json(temp.string.__text);
        return temp;
      })
      .catch((err) => {
        return err;
      });
  }
  /**
   * @Author: 唐宁坤
   * @Date: 2020-05-31 01:34:01
   * @Descripttion:
   */
  public httpGetNoAuth(url: string) {
    return Axios.get(url, {
      headers: {
        'Content-Type': 'application/json;charset=UTF-8',
      },
    })
      .then((response) => {
        return response.data;
      })
      .catch((err) => {
        return err;
      });
  }
  /**
   * @Author: 唐宁坤
   * @Date: 2020-05-31 01:34:05
   * @Descripttion:
   */
  public httpPostFormData(url: string, body: any) {
    return Axios({
      method: 'POST',
      data: body,
      url,
    })
      .then((response) => {
        console.log('httpPostFormData: ', response);
        return response.data;
      })
      .catch((err) => {
        return err;
      });
  }

  public httpPostNoAuthFrom(url: string, body: any) {
    return Axios({
      method: 'POST',
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8',
      },
      data: body,
      url,
    })
      .then((response) => {
        /*console.log('httpPostNoAuthFrom: ', response);*/
        return response.data;
      })
      .catch((err) => {
        return err;
      });
  }
  /**
   * @Author: 唐宁坤
   * @Date: 2020-05-31 01:36:40
   * @Descripttion: 调用自定义Axios获取数据
   * @url: 请求路径
   * @data:封装成json数据,自定义json回自动处理
   */
  public httpPostInterceptors(path: string, data: any) {
    let result = Interceptors({
      url: path,
      method: 'post',
      data,
    });
    return result;
  }
  /**
   * @Author: 唐宁坤
   * @Date: 2020-05-31 01:36:40
   * @Descripttion: 调用自定义Axios获取数据
   * @url: 请求路径
   * @data:封装成json数据,自定义json回自动处理|可为null
   */
  public httpGetInterceptors(path: string, data?: any) {
    let result = Interceptors({
      url: path,
      method: 'get',
      params: data,
    });
    return result;
  }
}
