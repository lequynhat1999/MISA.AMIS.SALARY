<template>
  <div class="box-gird">
    <DxDataGrid
      :data-source="dataSource"
      :remote-operations="false"
      :allow-column-reordering="true"
      :row-alternation-enabled="true"
      :show-borders="true"
      @content-ready="onContentReady"
      :height="430"
      :column-width="270"
      :allow-column-resizing="true"
      :column-resizing-mode="currentMode"
      :column-min-width="180"
      :column-auto-width="true"
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
        cell-template="discountCellTemplate"
        css-class="bullet"
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
      <DxColumn data-field="Region" caption="Trạng thái" data-type="string" />

      <DxScrolling column-rendering-mode="virtual" />
      <DxSearchPanel
        :visible="true"
        :highlight-case-sensitive="true"
        placeholder="Tìm kiếm"
      />
      <DxGrouping :auto-expand-all="false" />
      <DxPager
        :allowed-page-sizes="pageSizes"
        :show-page-size-selector="true"
      />
      <DxPaging :page-size="10" />
    </DxDataGrid>
  </div>
</template>

<script>
import {
  DxDataGrid,
  DxColumn,
  DxGrouping,
  //   DxGroupPanel,
  DxSelection,
  DxPager,
  DxPaging,
  DxScrolling,
  DxSearchPanel,
} from "devextreme-vue/data-grid";

import DataSource from "devextreme/data/data_source";
import "devextreme/data/odata/store";
let collapsed = false;

export default {
  components: {
    DxDataGrid,
    DxColumn,
    DxGrouping,
    // DxGroupPanel,
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
      pageSizes: [10, 25, 50, 100],
      // data cho checkbox
      allMode: "page",
      checkBoxesMode: "always",
      // data cho resize column
      resizingModes: ["nextColumn", "widget"],
      currentMode: "widget",
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
  },
};
</script>

<style scoped>
@import "../../css/base/grid.css";
</style>