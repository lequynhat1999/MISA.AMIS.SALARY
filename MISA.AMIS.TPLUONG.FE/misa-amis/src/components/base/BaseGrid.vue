<template>
  <div class="box-gird">
    <DxDataGrid
      ref="dxDataGrid"
      :data-source="dataSource"
      :remote-operations="false"
      :allow-column-reordering="true"
      :show-borders="true"
      noDataText="Không có dữ liệu"
      height="100%"
      :allow-column-resizing="true"
      :column-resizing-mode="currentMode"
      :column-min-width="100"
      :column-auto-width="true"
      :hover-state-enabled="true"
      @content-ready="onContentReady"
      @selection-changed="onSelectionChanged"
      @row-dbl-click="onRowDblClick"
    >
      <DxSelection
        :select-all-mode="allMode"
        :show-check-boxes-mode="checkBoxesMode"
        mode="multiple"
        :fixed="true"
      />
      <DxColumn
        v-for="(item, index) in headerGrid"
        :key="index"
        :data-field="item.DataField"
        :caption="item.Caption"
        :width="item.Width"
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
          <div :title="data.data[data.column.dataField]">
            {{ formatValueNull(data.data[data.column.dataField]) }}
          </div>
        </slot>
      </template>

      <template #option="{ data }">
        <div class="box-option">
          <div class="box-btn flex a-l-c">
            <div
              v-if="data.data.StatusName == 'Đang theo dõi'"
              class="btn-unfollow"
              title="Ngừng theo dõi"
              @click="openPopupUnfollow(data)"
            ></div>
            <div
              class="btn-follow"
              title="Đang theo dõi"
              @click="openPopupFollow(data)"
              v-else
            ></div>
            <div
              class="btn-clone"
              title="Nhân bản"
              @click="cloneRow(data)"
            ></div>
            <div
              class="btn-edit"
              title="Chỉnh sửa"
              @click="openFormDetail(data)"
            ></div>
            <div
              class="btn-delete"
              title="Xóa"
              @click="openPopupDelete(data)"
            ></div>
          </div>
        </div>
      </template>

      <DxLoadPanel :enabled="true"
       />
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
  DxLoadPanel,
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
    DxLoadPanel,
  },
  // props: ["headers", "dataSource"],
  props: {
    dataSource: {
      type: Array,
    },
    headers: {
      type: Array,
    },
    headersDefault: {
      type: Array,
    },
    headerGrid: {
      type: Array,
    },
  },
  data() {
    return {
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

    /**---------------------------------------------------------
     * Bắt sự kiện click vào row
     * CreatedBy:LQNHAT(21/09/2021)
     */
    onRowDblClick(e) {
      this.$emit("onRowDblClick", e.data);
    },

    /**-----------------------------------------------------------
     * Mở form detail
     * CreatedBy: LQNHAT(23/09/2021)
     */
    openFormDetail(e) {
      this.$emit("openFormDetail", e.data);
    },

    /**--------------------------------------------------------------
     * Bắt sự kiện delete row
     * CreatedBy: LQNHAT(21/09/2021)
     */
    openPopupDelete(e) {
      this.$emit("openPopupDelete", e.data);
    },

    /**---------------------------------------------------------------
     * Bắt sự kiện unfollow
     * CreatedBy: LQNHAT(22/09/2021)
     */
    openPopupUnfollow(e) {
      this.$emit("openPopupUnfollow", e.data);
    },

    /*-----------------------------------------------------------
     * Bắt sự kiện follow
     * CreatedBy: LQNHAT(24/09/2021)
     */
    openPopupFollow(e) {
      this.$emit("openPopupFollow", e.data);
    },

    /**-----------------------------------------------------------------
     * Bắt sự kiện nhân bản
     * CreatedBy: LQNHAT(23/09/2021)
     */
    cloneRow(e) {
      this.$emit("cloneRow", e.data);
    },

    /**---------------------------------------------------------------
     * Format value null
     * CreatedBy: LQNHAT(21/09/2021)
     */
    formatValueNull(value) {
      if (value == 0 || value == "" || value == null) return "-";
      else return value;
    },
  },
};
</script>

<style scoped>
@import "../../css/base/grid.css";
</style>