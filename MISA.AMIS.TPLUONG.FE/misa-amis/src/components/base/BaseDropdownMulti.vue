<template>
  <div class="dx-field-value" :class="{'view-read' : hiddenBoxBtn}">
    <DxDropDownBox 
      :value="value"
      :show-clear-button="true"
      :disabled="hiddenBoxBtn"
      :data-source="treeDataSource"
      :value-expr="valueExprProp"
      :display-expr="displayExprProp"
      :placeholder="placeholderProp"
      @value-changed="syncTreeViewSelection($event)"
    >
      <!-- field-template="list-item" -->
      <template #content="{}">
        <DxTreeView
          :searchEnabled="true"
          :value="value"
          root-value="00000000-0000-0000-0000-000000000000"
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
          @content-ready="contentReady($event)"
          @item-selection-changed="treeView_itemSelectionChanged($event)"
        />
      </template>

      <!-- <template #list-item="{data}">
        <div class="dx-field-value">
          <DxTextBox :value="data" style="height:3px !important"/>

        </div>
      </template> -->
    </DxDropDownBox>
  </div>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
// import DxTextBox from 'devextreme-vue/text-box';
export default {
  name: "BaseDropdownMulti",
  components: {
    DxDropDownBox,
    DxTreeView,
    // DxTextBox
  },
  // props: [
  //   "treeDataSource",
  //   "placeholderProp",
  //   "valueExprProp",
  //   "displayExprProp",
  //   "parentIdExprProp",
  //   "valueDefault",
  //   "value",
  // ],
  props: {
    treeDataSource: {
      type: Array
    },
    placeholderProp : {
      type: String,
    },
    valueExprProp: {
      type: String,
    },
    displayExprProp: {
      type: String,
    },
    parentIdExprProp: {
      type: String,
    },
    value: {
      type: [Array,String],
    },
    hiddenBoxBtn:{
      type: Boolean,
    }
  },
  data() {
    return {
      treeBoxValue: this.value,
      treeViewName: "treeView",
      isFirst: true,
    };
  },
  created() {
    // set value default cho dropdown single
    //this.treeBoxValue = [this.valueDefault];
  },
  methods: {
    contentReady(e){
      if(this.isFirst){
        this.$refs[this.treeViewName].instance.unselectAll();
        this.syncTreeViewSelection(e);
        this.isFirst = false;
      }
    },
    /**--------------------------------------------------------------
     * Bắt sự kiện khi value thay đổi
     * CreatedBy:LQNHAT(16/09/2021)
     */
    syncTreeViewSelection(e) {
      let treeView =
        (e.component.selectItem && e.component) ||
        (this.$refs[this.treeViewName] &&
          this.$refs[this.treeViewName].instance);

      if (treeView) {
        if (this.value == null) {
          treeView.unselectAll();
        } else {
          let values = e.value || this.value;
          
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
      this.$emit("getListSelected",e.component.getSelectedNodes());
    },
  },
};
</script>

<style>
@import "../../css/base/dropdown-multi.css";
</style>