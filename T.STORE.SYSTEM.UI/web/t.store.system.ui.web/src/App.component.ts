/*
 * @Descripttion:
 * @version: 1.0
 * @Author: 唐宁坤
 * @Date: 2020-05-16 11:33:33
 * @LastEditors: 唐宁坤
 * @LastEditTime: 2020-06-07 23:37:05
 */

import { Component, Vue, Model, Provide } from 'vue-property-decorator';
import Injectable from './Injectable';
import { Module } from '@vue-ioc/core';
import { HttpServices } from './http/HttpServices';
import { RouteService } from './services/RouteService';
import { HttpUrlConfig } from './http/HttpUrlConfig';
import { EventBus } from './utils/EventBus';

@Module({
  providers: [HttpServices, RouteService, HttpUrlConfig, EventBus],
})
@Component({
  name: 'app',
  mixins: [Injectable],
})
export default class App extends Vue {
  private loading: boolean = false;

  public computed() {
    // computed
  }
  public watch() {
    // watch
  }
  public methods() {
    // methods
  }
}
