import { Component, OnInit, Injector } from '@angular/core';
import { STComponentBase, AlainService } from '@shared/osharp/services/ng-alain.service';
import { OsharpSTColumn } from '@shared/osharp/services/ng-alain.types';

@Component({
  selector: 'app-pack',
  templateUrl: './pack.component.html',
  styles: []
})
export class PackComponent extends STComponentBase implements OnInit {

  constructor(injector: Injector, private alain: AlainService) {
    super(injector);
    this.moduleName = 'pack';
  }

  ngOnInit() {
    super.InitBase();
  }

  protected GetSTColumns(): OsharpSTColumn[] {
    return [
      { title: '', index: '', type: 'no' },
      { title: '名称', index: 'Display' },
      { title: '类型', index: 'Class' },
      { title: '级别', index: 'Level', type: 'tag', tag: this.alain.PackLevelTags },
      { title: '启动顺序', index: 'Order' },
      { title: '是否启用', index: 'IsEnabled' },
    ];
  }
}
