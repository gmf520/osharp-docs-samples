import { Component, OnInit, Injector } from '@angular/core';
import { SFUISchema } from '@delon/form';
import { OsharpSTColumn } from '@shared/osharp/services/ng-alain.types';
import { STComponentBase, } from '@shared/osharp/components/st-component-base';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styles: []
})
export class PostComponent extends STComponentBase implements OnInit {

  constructor(injector: Injector) {
    super(injector);
    this.moduleName = 'post';
  }

  ngOnInit() {
    super.InitBase();
  }

  protected GetSTColumns(): OsharpSTColumn[] {
    let columns: OsharpSTColumn[] = [
      {
        title: '操作', fixed: 'left', width: 65, buttons: [{
          text: '操作', children: [
            { text: '编辑', icon: 'edit', acl: 'Root.Admin.Blogs.Post.Update', iif: row => row.Updatable, click: row => this.edit(row) },
            { text: '删除', icon: 'delete', type: 'del', acl: 'Root.Admin.Blogs.Post.Delete', iif: row => row.Deletable, click: row => this.delete(row) },
          ]
        }]
      },
      { title: '编号', index: 'Id', sort: true, readOnly: true, editable: true, filterable: true, ftype: 'number' },
      { title: '文章标题', index: 'Title', sort: true, editable: true, filterable: true, ftype: 'string' },
      { title: '文章内容', index: 'Content', sort: true, editable: true, filterable: true, ftype: 'string' },
      { title: '博客编号', index: 'BlogId', readOnly: true, sort: true, filterable: true, type: 'number' },
      { title: '作者编号', index: 'UserId', readOnly: true, sort: true, filterable: true, type: 'number' },
      { title: '创建时间', index: 'CreatedTime', sort: true, filterable: true, type: 'date' },
    ];
    return columns;
  }

  protected GetSFUISchema(): SFUISchema {
    let ui: SFUISchema = {
      '*': { spanLabelFixed: 100, grid: { span: 12 } },
      $Title: { grid: { span: 24 } },
      $Content: { widget: 'textarea', grid: { span: 24 } }
    };
    return ui;
  }
}

