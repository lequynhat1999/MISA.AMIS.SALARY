<template>
  <div class="box-gird">
    <DxDataGrid
      :data-source="dataSource"
      :remote-operations="false"
      :allow-column-reordering="true"
      :show-borders="true"
      @content-ready="onContentReady"
      :height="430"
      :column-width="250"
      :allow-column-resizing="true"
      :column-resizing-mode="currentMode"
      :column-min-width="180"
      :column-auto-width="true"
      :hover-state-enabled="true"
    >
      <DxSelection
        :select-all-mode="allMode"
        :show-check-boxes-mode="checkBoxesMode"
        mode="multiple"
        :fixed="true"
      />

      <DxColumn
        data-field="Amount"
        caption="Mã thành phần"
        data-type="number"
        format="currency"
        alignment="left"
        :fixed="true"
      />
      <DxColumn
        :allow-grouping="false"
        data-field="Discount"
        caption="Tên thành phần"
        data-type="number"
        format="percent"
        alignment="left"
        :fixed="true"
      />
      <DxColumn
        data-field="SaleDate"
        caption="Đơn vị áp dụng"
        data-type="date"
      />

      <DxColumn
        data-field="Sector"
        caption="Loại thành phần"
        data-type="string"
      />
      <DxColumn data-field="Channel" caption="Tính chất" data-type="string" />
      <DxColumn data-field="Customer" caption="Giá trị" data-type="string" />
      <DxColumn
        data-field="Region"
        caption="Trạng thái"
        data-type="string"
        cell-template="cellTemplate"
      />

      <DxScrolling column-rendering-mode="virtual" />
      <DxSearchPanel
        :visible="true"
        :highlight-case-sensitive="false"
        :highlight-search-text="false"
        placeholder="Tìm kiếm"
      />
      <DxGrouping :auto-expand-all="false" />
      <DxPager
        :allowed-page-sizes="pageSizes"
        :show-page-size-selector="true"
        :display-mode="displayMode"
      />
      <DxPaging :page-size="10" />

      <template #cellTemplate="{}">
        <DxButton icon="edit" :on-click="myCommand" />
      </template>
    </DxDataGrid>
  </div>
</template>

<script>
import {
  DxDataGrid,
  DxColumn,
  DxGrouping,
  DxSelection,
  DxPager,
  DxPaging,
  DxScrolling,
  DxSearchPanel,
} from "devextreme-vue/data-grid";
import DxButton from "devextreme-vue/button";
import DataSource from "devextreme/data/data_source";
import "devextreme/data/odata/store";
let collapsed = false;

export default {
  components: {
    DxDataGrid,
    DxColumn,
    DxButton,
    DxGrouping,
    DxPager,
    DxPaging,
    DxScrolling,
    DxSearchPanel,
    DxSelection,
  },
  data() {
    return {
      dataSource: new DataSource({
        store: {
          type: "odata",
          url: "https://js.devexpress.com/Demos/SalesViewer/odata/DaySaleDtoes",
          key: "Id",
          beforeSend: function (request) {
            request.params.startDate = "2020-05-10";
            request.params.endDate = "2020-05-15";
          },
        },
      }),
      // pageSize chọn số bản ghi/trang
      pageSizes: [10, 25, 50, 100],
      // data cho checkbox
      allMode: "page",
      checkBoxesMode: "always",
      // data cho resize column
      resizingModes: ["nextColumn", "widget"],
      currentMode: "widget",
      // data cho paging
      displayMode: "compact",
      onContentReady: function (e) {
        if (!collapsed) {
          e.component.expandRow(["EnviroCare"]);
          collapsed = true;
        }
      },
    };
  },
  methods: {
    onSelectionChanged(e) {
      alert(e.value);
    },
    myCommand() {
      console.log(1);
    },
  },
};
</script>

<style scoped>
@import "../../css/base/grid.css";
</style>