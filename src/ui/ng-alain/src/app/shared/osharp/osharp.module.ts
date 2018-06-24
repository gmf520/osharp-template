import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OsharpService } from '@shared/osharp/services/osharp.service';
import { KendouiService } from '@shared/osharp/services/kendoui.service';
import { RemoteValidator } from '@shared/osharp/directives/remote-validator.directive';
import { KendouiFunctionComponent } from '@shared/osharp/components/kendoui-function.component';
import { KendouiSplitterComponent } from '@shared/osharp/components/kendoui-splitter.component';
import { KendouiTabstripComponent } from '@shared/osharp/components/kendoui-tabstrip.component';
import { KendouiTreeviewComponent } from '@shared/osharp/components/kendoui-treeview.component';
import { KendouiWindowComponent } from '@shared/osharp/components/kendoui-window.component';
import { OsharpCacheModule } from '@shared/osharp/cache/cache.module';
import { IdentityService } from '@shared/osharp/services/identity.service';

const DIRECTIVES = [
  RemoteValidator
];

const COMPONENTS = [
  KendouiFunctionComponent,
  KendouiSplitterComponent,
  KendouiTabstripComponent,
  KendouiTreeviewComponent,
  KendouiWindowComponent,
];

const SERVICES = [
  OsharpService,
  KendouiService,
  IdentityService
];

@NgModule({
  declarations: [
    ...DIRECTIVES,
    ...COMPONENTS
  ],
  imports: [
    CommonModule,
    OsharpCacheModule.forRoot()
  ],
  exports: [
    ...DIRECTIVES,
    OsharpCacheModule,
    ...COMPONENTS
  ],
  providers: [
    ...SERVICES
  ],
})
export class OsharpModule {

}
