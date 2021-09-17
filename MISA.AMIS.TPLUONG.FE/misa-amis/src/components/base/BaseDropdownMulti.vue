<template>
  <div class="dx-field-value">
    <DxDropDownBox
      :value="treeBoxValue"
      :show-clear-button="true"
      :data-source="treeDataSource"
      :value-expr="valueExprProp"
      :display-expr="displayExprProp"
      :placeholder="placeholderProp"
      @value-changed="syncTreeViewSelection($event)"
    >
      <template #content="{}">
        <DxTreeView
          :searchEnabled="true"
          :value="treeBoxValue"
          placeholder=" Tìm kiếm"
          noDataText="Không có dữ liệu"
          ref="treeView"
          :data-source="treeDataSource"
          :select-by-click="true"
          :select-nodes-recursive="true"
          data-structure="plain"
          :key-expr="valueExprProp"
          :parent-id-expr="parentIdExprProp"
          selection-mode="multiple"
          show-check-boxes-mode="normal"
          :display-expr="displayExprProp"
          @content-ready="syncTreeViewSelection($event)"
          @item-selection-changed="treeView_itemSelectionChanged($event)"
        />
      </template>

      <!-- <template #list-item="{data}">
        <div class="dx-field-value">
          <DxTextBox :value="data" style="height:3px !important"/>
          <DxTagBox
            :data-source="treeDataSource"
            :value-expr="valueExprProp"
            :display-expr="displayExprProp"
          />

        </div>
      </template> -->
    </DxDropDownBox>
  </div>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
// import DxTextBox from 'devextreme-vue/text-box';
// import DxTagBox from "devextreme-vue/tag-box";
export default {
  name: "BaseDropdownMulti",
  components: {
    DxDropDownBox,
    DxTreeView,
    // DxTextBox
    // DxTagBox,
  },
  props: [
    "treeDataSource",
    "placeholderProp",
    "valueExprProp",
    "displayExprProp",
    "parentIdExprProp",
    "valueDefault",
  ],
  data() {
    return {
      treeBoxValue: null,
      treeViewName: "treeView",
    };
  },
  created() {
    // set value default cho dropdown single
    this.treeBoxValue = [this.valueDefault];
  },
  methods: {
    /**--------------------------------------------------------------
     * Bắt sự kiện khi value thay đổi
     * CreatedBy:LQNHAT(16/09/2021)
     */
    syncTreeViewSelection(e) {
      console.log("value-changed: " + e.value);
      let treeView =
        (e.component.selectItem && e.component) ||
        (this.$refs[this.treeViewName] &&
          this.$refs[this.treeViewName].instance);

      if (treeView) {
        if (e.value === null) {
          treeView.unselectAll();
        } else {
          let values = e.value || this.treeBoxValue;
          for (let index = 0; index < values.length; index++) {
            treeView.selectItem(values[index]);
          }
        }
      }
    },

    /**--------------------------------------------------------------
     * Bắt sự kiện khi item được chọn thay đổi
     * CreatedBy:LQNHAT(17/09/2021)
     */
    treeView_itemSelectionChanged(e) {
      console.log(e);
      this.treeBoxValue = e.component.getSelectedNodeKeys();
    },
  },
};
</script>

<style>
@import "../../css/base/dropdown-multi.css";
</style>