import { Component, OnInit, Injector } from '@angular/core';
import { SFUISchema, SFSchema } from '@delon/form';
import { OsharpSTColumn } from '@shared/osharp/services/ng-alain.types';
import { STComponentBase, } from '@shared/osharp/components/st-component-base';
import { STData } from '@delon/abc';
import { AjaxResult } from '@shared/osharp/osharp.model';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styles: []
})
export class BlogComponent extends STComponentBase implements OnInit {

  constructor(injector: Injector) {
    super(injector);
    this.moduleName = 'blog';
  }

  ngOnInit() {
    super.InitBase();
    this.createUrl = `api/admin/${this.moduleName}/apply`;
  }

  protected GetSTColumns(): OsharpSTColumn[] {
    let columns: OsharpSTColumn[] = [
      {
        title: '操作', fixed: 'left', width: 65, buttons: [{
          text: '操作', children: [
            { text: '审核', icon: 'flag', acl: 'Root.Admin.Blogs.Blog.Verify', iif: row => !row.IsEnabled, click: row => this.verify(row) },
            { text: '编辑', icon: 'edit', acl: 'Root.Admin.Blogs.Blog.Update', iif: row => row.Updatable, click: row => this.edit(row) },
          ]
        }]
      },
      { title: '编号', index: 'Id', sort: true, readOnly: true, editable: true, filterable: true, ftype: 'number' },
      { title: '博客地址', index: 'Url', sort: true, editable: true, filterable: true, ftype: 'string' },
      { title: '显示名称', index: 'Display', sort: true, editable: true, filterable: true, ftype: 'string' },
      { title: '已开通', index: 'IsEnabled', sort: true, filterable: true, type: 'yn' },
      { title: '作者编号', index: 'UserId', type: 'number' },
      { title: '创建时间', index: 'CreatedTime', sort: true, filterable: true, type: 'date' },
    ];
    return columns;
  }

  protected GetSFUISchema(): SFUISchema {
    let ui: SFUISchema = {
      '*': { spanLabelFixed: 100, grid: { span: 12 } },
      $Url: { grid: { span: 24 } },
      $Display: { grid: { span: 24 } },
    };
    return ui;
  }

  create() {
    if (!this.editModal) {
      return;
    }
    this.schema = this.GetSFSchema();
    this.ui = this.GetSFUISchema();
    this.editRow = {};
    this.editTitle = "申请博客";
    this.editModal.open();
  }

  save(value: STData) {
    // 申请博客
    if (!value.Id) {
      this.http.post<AjaxResult>(this.createUrl, value).subscribe(result => {
        this.osharp.ajaxResult(result, () => {
          this.st.reload();
          this.editModal.destroy();
        });
      });
      return;
    }
    // 审核博客
    if (value.Reason) {
      let url = 'api/admin/blog/verify';
      this.http.post<AjaxResult>(url, value).subscribe(result => {
        this.osharp.ajaxResult(result, () => {
          this.st.reload();
          this.editModal.destroy();
        });
      });
      return;
    }
    super.save(value);
  }

  verify(value: STData) {
    if (!value || !this.editModal) return;
    this.schema = {
      properties: {
        Id: { title: '编号', type: 'number', readOnly: true, default: value.Id },
        Name: { title: '博客名', type: 'string', readOnly: true, default: value.Display },
        IsEnabled: { title: '是否开通', type: 'boolean' },
        Reason: { title: '审核理由', type: 'string' }
      },
      required: ['Reason']
    };
    this.ui = {
      '*': { spanLabelFixed: 100, grid: { span: 12 } },
      $Id: { widget: 'text' },
      $Name: { widget: 'text', grid: { span: 24 } },
      $Reason: { widget: 'textarea', grid: { span: 24 } }
    };
    this.editRow = value;
    this.editTitle = "审核博客";
    this.editModal.open();
  }
}

