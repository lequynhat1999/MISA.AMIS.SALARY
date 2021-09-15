<template>
  <div class="box-gird">
    <DxDataGrid
      :data-source="dataSource"
      :remote-operations="false"
      :allow-column-reordering="true"
      :show-borders="true"
      @content-ready="onContentReady"
      :height="385"
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
        v-for="(item, index) in headers"
        :key="index"
        :data-field="item.DataField"
        :caption="item.Caption"
        :data-type="item.DataType"
        :alignment="item.Alignment"
        :fixed="item.Fixed"
        cell-template="cellTemplate"
      />

      <template #cellTemplate="{ data }">
        <!-- <div @click="test(data)">a</div> -->
        <slot :name="data.column.dataField" :data="data.data">

        </slot>
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
      console.log(data);
    },
  },
};
</script>

<style scoped>
@import "../../css/base/grid.css";
</style>