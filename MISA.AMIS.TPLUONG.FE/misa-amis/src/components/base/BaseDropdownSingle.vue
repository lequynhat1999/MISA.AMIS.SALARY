<template>
  <div class="dx-field-value">
    <DxDropDownBox
      :value="treeBoxValue"
      ref="dropdownBox"
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
          :ref="treeViewRefName"
          noDataText="Không có dữ liệu"
          :data-source="treeDataSource"
          :select-by-click="true"
          data-structure="plain"
          :key-expr="valueExprProp"
          root-value="00000000-0000-0000-0000-000000000000"
          :parent-id-expr="parentIdExprProp"
          selection-mode="single"
          :display-expr="displayExprProp"
          @content-ready="$event.component.selectItem(treeBoxValue)"
          @item-selection-changed="treeView_itemSelectionChanged($event)"
          @item-click="onTreeItemClick($event)"
        />
      </template>
    </DxDropDownBox>
  </div>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
export default {
  name: "BaseDropdownSingle",
  components: {
    DxDropDownBox,
    DxTreeView,
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
      treeViewRefName: "tree-view",
    };
  },
  created() {
    // set value default cho dropdown single
    // this.treeBoxValue = this.valueDefault;
  },
  methods: {
    /**---------------------------------------------------------------------------------
     * Sự kiện được kích hoạt khi value thay đổi
     * CreatedBy: LQNHAT(15/09/2021)
     */
    syncTreeViewSelection() {
      if (!this.$refs[this.textBoxRefName]) return;
      if (!this.treeBoxValue) {
        this.$refs[this.textBoxRefName].instance.unselectAll();
      } else {
        this.$refs[this.textBoxRefName].instance.selectItem(this.treeBoxValue);
      }
    },
    /**---------------------------------------------------------------------------------
     * Sự kiện được kích hoạt khi content thay đổi
     * CreatedBy: LQNHAT(15/09/2021)
     */
    treeView_itemSelectionChanged(e) {
      this.treeBoxValue = e.component.getSelectedNodeKeys();
    },

    /**--------------------------------------------------------------------------------
     * Đóng dropdown khi click vào item
     * CreatedBy: LQNHAT(15/09/2021)
     */
    onTreeItemClick() {
      this.$refs.dropdownBox.instance.close();
    },
  },
};
</script>

<style  scoped>
@import "../../css/base/dropdown-single.css";
</style>