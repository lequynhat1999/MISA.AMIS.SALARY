<template>
  <div class="box-gird">
    <DxDataGrid
      ref="dxDataGrid"
      :data-source="dataSource"
      :remote-operations="false"
      :allow-column-reordering="true"
      :show-borders="true"
      @content-ready="onContentReady"
      height="100%"
      :column-width="250"
      :allow-column-resizing="true"
      :column-resizing-mode="currentMode"
      :column-min-width="180"
      :column-auto-width="true"
      :hover-state-enabled="true"
      @selection-changed="onSelectionChanged"
    >
      <DxSelection
        :select-all-mode="allMode"
        :show-check-boxes-mode="checkBoxesMode"
        mode="multiple"
        :fixed="true"
      />
      <DxColumn
        v-for="(item, index) in headers"
        :key="index"
        :data-field="item.DataField"
        :caption="item.Caption"
        :data-type="item.DataType"
        :alignment="item.Alignment"
        :fixed="item.Fixed"
        cell-template="cellTemplate"
      />

      <DxColumn
        alignment="center"
        :width="180"
        :fixed="true"
        fixed-position="right"
        cell-template="option"
      />

      <template #cellTemplate="{ data }">
        <slot :name="data.column.dataField" :data="data.data">
          <div :title= data.data[data.column.dataField]>{{ data.data[data.column.dataField] }}</div>
        </slot>
      </template>

      <template #option="{ data }">
        <div class="box-option">
          <div class="box-btn flex a-l-c">
            <div
              class="btn-follow"
              title="Ngừng theo dõi"
              @click="test(data)"
            ></div>
            <div class="btn-clone" title="Nhân bản"></div>
            <div class="btn-edit" title="Chỉnh sửa"></div>
            <div class="btn-delete" title="Xóa"></div>
          </div>
        </div>
      </template>

      <DxScrolling column-rendering-mode="virtual" />
      <DxGrouping :auto-expand-all="false" />
    </DxDataGrid>
  </div>
</template>

<script>
import {
  DxDataGrid,
  DxColumn,
  DxGrouping,
  DxSelection,
  DxScrolling,
} from "devextreme-vue/data-grid";
import "devextreme/data/odata/store";
let collapsed = false;
export default {
  components: {
    DxDataGrid,
    DxColumn,
    DxGrouping,
    DxScrolling,
    DxSelection,
  },
  props: ["headers", "dataSource"],
  data() {
    return {
      titleTd: "Hello",
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
    test(data) {
      console.log(data.data.SalaryCompositionID);
    },
    /**-------------------------------------------------------
     * Gửi những rows được checked sang cha
     * CreatedBy:LQNHAT(17/09/2021)
     */
    onSelectionChanged({ selectedRowsData }) {
      console.log(selectedRowsData);
      this.$emit("getRowChecked", selectedRowsData);
    },

    /**---------------------------------------------------------
     * Hàm bắt sự kiện uncheckAll
     * CreatedBy:LQNHAT(17/09/2021)
     */
    uncheckAllRow() {
      this.$refs.dxDataGrid.instance.deselectAll();
    },
  },
};
</script>

<style scoped>
@import "../../css/base/grid.css";
</style>