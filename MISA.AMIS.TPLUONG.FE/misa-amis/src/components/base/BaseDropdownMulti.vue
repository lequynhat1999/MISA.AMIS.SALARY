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
          :ref="treeViewName"
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
    </DxDropDownBox>
  </div>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
export default {
  name: "BaseDropdownMulti",
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
      treeViewName: 'tree-view',
    };
  },
  created() {
    // set value default cho dropdown single
    this.treeBoxValue = this.valueDefault;
  },
  methods: {
    syncTreeViewSelection(e) {
        console.log("value-changed: " + e.value);
      let treeView =
        (e.component.selectItem && e.component) ||
        (this.$refs[this.treeViewName] &&
          this.$refs[this.treeViewName].instance);

      if (treeView) {
        if (e.value === null) {
          treeView.unselectAll();
        } 
        else {
          let values = e.value || this.treeBoxValue;
          console.log("số lượng item: " + values.length);
        //   values &&
        //     values.forEach((value) => {
        //       treeView.selectItem(value);
        //     });
        for (let index = 0; index < values.length; index++) {
            treeView.selectItem(values[index]);
        }
        }
      }
    },
    treeView_itemSelectionChanged(e) {
        console.log(e);
      this.treeBoxValue = e.component.getSelectedNodeKeys();
      console.log("treeBoxValue: " + this.treeBoxValue);
    },
  },
};
</script>

<style>
@import "../../css/base/dropdown-multi.css";
</style>