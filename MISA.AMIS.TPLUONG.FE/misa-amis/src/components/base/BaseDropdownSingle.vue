<template>
  <div class="dx-field-value">
    <DxDropDownBox
      :value="treeBoxValue"
      :opened="isTreeBoxOpened"
      :show-clear-button="true"
      :data-source="treeDataSource"
      value-expr="ID"
      display-expr="name"
      placeholder=""
      @value-changed="syncTreeViewSelection($event)"
    >
      <template #content="{}">
        <DxTreeView
          :searchEnabled="true"
          :ref="treeViewRefName"
          :data-source="treeDataSource"
          :select-by-click="true"
          data-structure="plain"
          key-expr="OrganizationUnitID"
          parent-id-expr="ParentID"
          selection-mode="single"
          display-expr="OrganizationUnitName"
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
  props:["treeDataSource"],
  data() {
      return {
          
          treeBoxValue: null,
          isTreeBoxOpened: false,
          treeViewRefName: "tree-view",
      }
  },
  created() {
  },
  methods: {
    
  },
};
</script>

<style  scoped>
@import "../../css/base/dropdown-single.css";
</style>